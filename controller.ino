#include<Stepper.h>
#include<stdlib.h>
int deger = 0;
char buffer1[8] = {0,0,0,0,0,0,0,0};
unsigned int zaman=0;
unsigned int donmeacisi=0;
int sayac = 0;
int tempDeger = 0;
int i = 0, j = 0;
boolean durdurBasla = false;
boolean durum;
int k = 0;
int tut = 0;
int kalanSayac = 0;
int pin1 = 8;
int pin2 = 10;
int pin3 = 9;
int pin4 = 11;
Stepper  motor = Stepper(2048, 8, 10, 9, 11);
void setup() {
  motor.setSpeed(10);
  Serial.begin(9600);
  pinMode(pin1, OUTPUT);
  pinMode(pin2, OUTPUT);
  pinMode(pin3, OUTPUT);
  pinMode(pin4, OUTPUT);
  

}
void stopMotor(){
   digitalWrite(pin1, LOW);
   digitalWrite(pin2, LOW);
   digitalWrite(pin3, LOW);
   digitalWrite(pin4, LOW);
}
void loop() {

  int tut = 0;
  if(deger < 253){
    tut = deger * 5.68;
  }
   
  tempDeger = deger * 5.68;
  sayac = 2048 / tempDeger;
  kalanSayac = sayac;
 
    if(durdurBasla == false){
      for(i = 0; i < sayac; i++, kalanSayac--){
       
       deger = Serial.read(); 
        
         if(durum == false){
            motor.step(tut);
            durdurBasla = true;
            
            break;
    }
    else{
        
     
     if(deger == 254){
        durum = false;
     }
     else{
      if(deger == 253){
        motor.step(-tut);
      
         delay(zaman);
      }
      else{
        motor.step(-tempDeger * 5);
        stopMotor();
        delay(zaman);
       
      }
      
     }
     
    }
    
   
  }
    }
    
  
  else if(durdurBasla == true){
    for(j = 0; j < kalanSayac; j++){
       
       deger = Serial.read(); 
        
         if(durum == false){
            motor.step(tut);
            durdurBasla = false;
            
            break;
    }
    else{
        
     durdurBasla = false;
     if(deger == 254){
        durum = false;
     }
     else{
      if(deger == 253){
        motor.step(-tut);
        stopMotor();
        delay(zaman);
        
      }
      else{
        motor.step(-tempDeger * 5);
        stopMotor();
        delay(zaman);
      
      }
      
     }
      
    }
    
   
  }
  }
  digitalWrite(pin1, LOW);
  digitalWrite(pin2, LOW);
  digitalWrite(pin3, LOW);
  digitalWrite(pin4, LOW);
}

void serialEvent(){
  while(Serial.available()){ 
     Serial.readBytes(buffer1, 8);
     Serial.println(buffer1[0], DEC);
     Serial.println(buffer1[1], DEC);
     Serial.println(buffer1[2], DEC);
     Serial.println(buffer1[3], DEC);
     Serial.println(buffer1[4], DEC);
     Serial.println(buffer1[5], DEC);
     Serial.println(buffer1[6], DEC);
     Serial.println(buffer1[7], DEC);
     zaman=((int(buffer1[0]-48)*10000)+(int(buffer1[1]-48)*1000)+(int(buffer1[2]-48)*100)+int(buffer1[3]-48)*10)+int(buffer1[4]-48);
     Serial.println(zaman, DEC);
     donmeacisi= (int(buffer1[5]-48)*100)+(int(buffer1[6]-48)*10)+int(buffer1[7]-48);
     Serial.println(donmeacisi, DEC);
     deger=donmeacisi;
     if(deger == 254){
        durum = false;
     }
     else if(deger == 253){
      durum = true; 
     }
     else{
      durum = true;
     }
  }
  
}
