#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <DHT.h>

DHT dht(2, DHT22);

#define SERVER_IP "192.168.1.41"

#ifndef STASSID
#define STASSID "Livebox-b102_2.4g"
#define STAPSK  "azerty58180"
#endif

void setup() {
  Serial.begin(115200);
  dht.begin();
  
  Serial.println();
  WiFi.begin(STASSID, STAPSK);
  Serial.print("Connecting to WiFi network " STASSID " ");
  while (WiFi.status() != WL_CONNECTED) {
    delay(300);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected! IP address: ");
  Serial.println(WiFi.localIP());
}

void loop() {
  if ((WiFi.status() == WL_CONNECTED)) {

    WiFiClient client;
    HTTPClient http;
    
    float h = dht.readHumidity();
    float t = dht.readTemperature();

    if (isnan(h) || isnan(t)) {
      Serial.println("Failed to read values from DHT sensor.");
    }
    else{
      Serial.println("{\"temperature\":"+String(t, 2)+", \"humidity\":"+String(h, 2)+"}");
      http.begin(client, "http://" SERVER_IP "/api/Moment");
      http.addHeader("Content-Type", "application/json");
      http.POST("{\"temperature\":"+String(t, 2)+", \"humidity\":"+String(h, 2)+"}");
      http.end();
    }
  }

  delay(5000);
}
