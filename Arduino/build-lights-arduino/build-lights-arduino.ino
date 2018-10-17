const int redPin = 10;  //0 position
const int greenPin = 9; //1 position
const int yellowPin = 8;//2 position

const int redFlagPosition = 0;  //0 position
const int greenFlagPosition = 1; //1 position
const int yellowFlagPosition = 2;//2 position

byte lightFlags = 0;

void setup() {
 // initialize serial:
  Serial.begin(9600);
  // make the pins outputs:
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(yellowPin, OUTPUT);

}

void loop() {
  //if there's any serial available, read it:
  while (Serial.available() > 0) {
    lightFlags = (byte)Serial.parseInt();
    if (Serial.read() == '\n') {
      setLightPinState(redPin, redFlagPosition);
      setLightPinState(greenPin, greenFlagPosition);
      setLightPinState(yellowPin, yellowFlagPosition);
    }
  }
}


void setLightPinState(int pin, int position){
   if(bitRead(lightFlags, position)==1){
      digitalWrite(pin, HIGH);
    }
    else{
      digitalWrite(pin, LOW);
    }
}
