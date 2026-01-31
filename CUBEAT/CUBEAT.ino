
#include <Keypad.h>
#include <Keyboard.h>

float BT2PREV = false ; 
float BT3PREV = false ; 
float BT4PREV = false ; 
float BT5PREV = false ; 
float BT6PREV = false ; 
float BT7PREV = false ; 
float BT8PREV = false ; 
float BT9PREV = false ; 
float BT10PREV = false ; 
 
void setup()
{


  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);
  pinMode(4, INPUT_PULLUP);
  pinMode(5, INPUT_PULLUP);
  pinMode(6, INPUT_PULLUP);
  pinMode(7, INPUT_PULLUP);
  pinMode(8, INPUT_PULLUP);
  pinMode(9, INPUT_PULLUP);
  pinMode(10, INPUT_PULLUP);
  
  Keyboard.begin();
  
}

void loop() 
{
 
  
  if(digitalRead(2)==LOW){
    if(BT2PREV == false){
     Keyboard.press(KEY_KP_7);
     BT2PREV = true;
    }
   
  } 
  else{
    if(BT2PREV == true){
     Keyboard.release(KEY_KP_7);
     BT2PREV = false;
    }
  }  
  
  if(digitalRead(3)==LOW){
    if(BT3PREV == false){
     Keyboard.press(KEY_KP_8);
     BT3PREV = true;
    }
   
  } 
  else{
    if(BT3PREV == true){
     Keyboard.release(KEY_KP_8);
     BT3PREV = false;
    }
  }  

  if(digitalRead(4)==LOW){
    if(BT4PREV == false){
     Keyboard.press(KEY_KP_9);
     BT4PREV = true;
    }
   
  } 
  else{
    if(BT4PREV == true){
     Keyboard.release(KEY_KP_9);
     BT4PREV = false;
    }
  }  

  if(digitalRead(5)==LOW){
    if(BT5PREV == false){
     Keyboard.press(KEY_KP_4);
     BT5PREV = true;
    }
   
  } 
  else{
    if(BT5PREV == true){
     Keyboard.release(KEY_KP_4);
     BT5PREV = false;
    }
  }  

  if(digitalRead(6)==LOW){
    if(BT6PREV == false){
     Keyboard.press(KEY_KP_5);
     BT6PREV = true;
    }
   
  } 
  else{
    if(BT6PREV == true){
     Keyboard.release(KEY_KP_5);
     BT6PREV = false;
    }
  }  

  if(digitalRead(7)==LOW){
    if(BT7PREV == false){
     Keyboard.press(KEY_KP_1);
     BT7PREV = true;
    }
   
  } 
  else{
    if(BT7PREV == true){
     Keyboard.release(KEY_KP_1);
     BT7PREV = false;
    }
  }  

  if(digitalRead(8)==LOW){
    if(BT8PREV == false){
     Keyboard.press(KEY_KP_2);
     BT8PREV = true;
    }
   
  } 
  else{
    if(BT8PREV == true){
     Keyboard.release(KEY_KP_2);
     BT8PREV = false;
    }
  }  

  if(digitalRead(9)==LOW){
    if(BT9PREV == false){
     Keyboard.press(KEY_KP_3);
     BT9PREV = true;
    }
   
  } 
  else{
    if(BT9PREV == true){
     Keyboard.release(KEY_KP_3);
     BT9PREV = false;
    }
  }  

  if(digitalRead(10)==LOW){
    if(BT10PREV == false){
     Keyboard.press(KEY_KP_6);
     BT10PREV = true;
    }
   
  } 
  else{
    if(BT10PREV == true){
     Keyboard.release(KEY_KP_6);
     BT10PREV = false;
    }
  }  
  
  delay(10);
}



 
