const int redPin = 9; 
const int greenPin = 10; 
const int yellowPin = 8;

const int redFlagPosition = 0;  //0 position
const int greenFlagPosition = 1; //1 position
const int yellowFlagPosition = 2;//2 position

byte lightFlags = 0;
String inString = "";    // string to hold input

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

    int inChar = Serial.read();
    if (isDigit(inChar)) {
      // convert the incoming byte to a char and add it to the string:
      inString += (char)inChar;
    }
    // if you get a newline, print the string, then the string's value:
    if (inChar == '\n') {
      /*Serial.print("Value:");
      Serial.println(inString.toInt());
      Serial.print("String: ");
      Serial.println(inString);
      // clear the string for new input:
      inString = "";*/
      Serial.print("Value:");
      Serial.println(inString.toInt());
      Serial.print("String: ");
      Serial.println(inString);
      lightFlags = (byte)inString.toInt();
      setLightPinState(redPin, redFlagPosition);
      setLightPinState(greenPin, greenFlagPosition);
      setLightPinState(yellowPin, yellowFlagPosition);
      inString = "";
    }

    /*
    lightFlags = (byte)Serial.parseInt();
    if (Serial.read() == '\n') {
      setLightPinState(redPin, redFlagPosition);
      setLightPinState(greenPin, greenFlagPosition);
      setLightPinState(yellowPin, yellowFlagPosition);
    }
    */
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
