# RaspberryPi-Control-UltraSoniceSensor-Example
<p>
How to control an Ultrasonic Sensor from a Raspberry Pi using Windows 10 IOT core.
</p>
<p>
<img style="float:left;" src="https://raw.githubusercontent.com/StuartSmith/RaspberryPi-Control-UltraSonicSensor/master/Images/UltraSonicWiringBySelf.jpg">
<p>An ultrasonic sensor, is a sensor that uses sound waves to measure the distance of an object.</p>  

<h2> How an Ultrasonic Sensor Works</h2>
<p>
The ultra sonic works very simply. A micro computer sends a electric pulse to it. The ultrasonic sensor intern sends out a sound wave when it recieves the pulse. The sound wave bounces off an object and returns to the ultrasonic sensor. The ultrasonic sensor then send a pulse back to the listening GPIO pin of the micro computer. 
</p>

<h2> Wiring the Ultrasonic Sensor to the Raspberry Pi </h2>
<p>
To wire the ultrasonic sensor to the Raspberry Pi,  4 GPIO pins are used: A Ground, A 5 volt power pin, and two 3 volt GPIO pins. A GPIO pin for the Raspberry Pi can only have 3.3 volts applied to it and the ultrasonic has the capabilty to send 5 volts from the echo pin back to the GPIO Pin of the PI. To avoid the ultrasonic sensor from sending too much voltage to the GPIO pin of the Raspberry Pi, a 1 K Ohm resiter is inserted, to bring the voltage down to an acceptable level. 

<ul>
<li>The Five Volt Power Pin of the Pi connects to the VCC pin of the ultrasonic sensor</li>
<li>The Gound Pin of the Pi connects to the GND pin of the ultrasonic sensor</li>
<li>The GPIO Pin 20 of the Pi connects to the Trigger Pin of the ultrasonic sensor</li>
<li>The GPIO Pin 21 of the Pi connects to the Echo Pin of the ultrasonic sensor</li>
</ul>

</p>
<img style="float:left;" src="https://raw.githubusercontent.com/StuartSmith/RaspberryPi-Control-UltraSonicSensor/master/Images/UltraSonicWiringToPi.jpg">



<h2> How to determine the distance using an Ultrasonic Sensor</h2>
<p>
Sound moves at 1,088 feet per second (332 meters per second).  Different air tempatures change the speed of sound but for this article, to keep things simple, we will assume sound moves at a constant speed no matter what the air temperature nor humidity is.
</p>


</p>

