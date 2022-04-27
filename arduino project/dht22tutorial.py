import requests
import Adafruit_DHT as dht
from time import sleep

dht_pin = 4
while True:
    h,t = dht.read_retry(dht.DHT22, dht_pin)
    requests.post("https://localhost:44380/api/Moment", data={'temperature': t, 'humidity': h})
    sleep(5)
