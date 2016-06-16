# RaspberryPi-Control-UltraSoniceSensor-Example
<p>
How to control an Ultra Sonic Sensor from a Raspberry Pi using Windows 10 IOT core.
</p>
<p>
<img style="float:left;" src="https://raw.githubusercontent.com/StuartSmith/RaspberryPi-Control-UltraSonicSensor/master/Images/UltraSonicWiringBySelf.jpg">
<p>An ultra sonic sensor, is a sensor that uses sound waves to measure the distance of an object.</p>  

<h2> Wiring the ultra sonic sensor to the Raspberry Pi </h2>
<p>
To wire the ultra sonic sensor to the Raspberry Pi, we need to use 4 pins. a Ground, a 5 volt power pin, and two 3 volt GPIO pins. A GPIO pin can only have 3.3 volts applied to it and the ultra sonic has the capabilty to send 5 volts it is best to add a 1 K Ohm resistor to the echo to prevent to much charge going back to the Raspberry Pi.
</p>
<img style="float:left;" src="https://raw.githubusercontent.com/StuartSmith/RaspberryPi-Control-UltraSonicSensor/master/Images/UltraSonicWiringToPi.jpg">

<h2> How to determine the distance using an ultra sonic sensor.</h2>
<p>
Sound moves at 1,088 feet per second (332 meters per second).  Different air tempatures change the speed of sound but for this article, to keep things simple we will say that sound moves at a constant speed not matter what the air temperature nor humidity is.
</p>


</p>

