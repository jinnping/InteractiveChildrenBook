#define trig 13
#define echo 12 
#define trig2 10 
#define echo2 11


const uint8_t pin_button[] = {
  2, 3, 4, 5, 6, 7, 8, 9
};
long t;
int distance;
long t2; 
int distance2; 



void setup() {
  pinMode(trig,OUTPUT);
  pinMode(echo,INPUT);
  pinMode(trig2,OUTPUT);
  pinMode(echo2,INPUT);
  for(int i = 0; i < sizeof(pin_button); i++)
    pinMode(pin_button[i], INPUT);

  Serial.begin(9600);
}

void loop() {

  for(int i = 0; i < sizeof(pin_button); i++) {
    if(digitalRead(pin_button[i])==HIGH) {
      Serial.println(String(i + 1));
      Serial.flush(); 
      while(digitalRead(pin_button[i])==HIGH)
         delayMicroseconds(1500);
    }
//    if(digitalRead(pin_button[i])==LOW){
//       Serial.println(0);
//       delay(1500);
//    }
    delay(10);
  }
  
  if(Serial.available()){
     int dist = GetDistance();
     int dist2 = GetDistance2();
     char mode = Serial.read();
     if(mode == 'A') {
        if(dist > 50) {
            Serial.println("50");
        }
        else {
            Serial.println("10");
            //Serial.println(String(dist));
        }
     }
     else if(mode =='B'){
        if(dist2 > 50) {
            Serial.println("51");
        }
        else {
            Serial.println("11");
            //Serial.println(String(dist2));
        }
     }
  }
}

int GetDistance() {
  digitalWrite(trig,LOW);
  delayMicroseconds(2);
  digitalWrite(trig,HIGH);
  delayMicroseconds(10);
  t = pulseIn(echo,HIGH);
  distance=(0.0343*t)/2;
  return distance;
}

int GetDistance2() {
  digitalWrite(trig2,LOW);
  delayMicroseconds(2);
  digitalWrite(trig2,HIGH);
  delayMicroseconds(10);
  t2 = pulseIn(echo2,HIGH);
  distance2=(0.0343*t2)/2;
  return distance2;
}
