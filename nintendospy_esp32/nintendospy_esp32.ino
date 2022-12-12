
/*Kevins ESP32 Nintendo Controller Overlay System*/
#include "game.h"
#define CLOCK_PIN 22
#define DATA_PIN 21
#define LATCH_PIN 27
GameControllers controllers;

void setup()
{
  Serial.begin(115200);
  controllers.init(LATCH_PIN, CLOCK_PIN); 
  //todo: add define to select controller type SNES/NES
  controllers.setController(0, GameControllers::SNES, DATA_PIN);
}
void loop()
{
 
    controllers.poll();
  if(controllers.down(0, GameControllers::B))
    Serial.printf("%d\n",0);
  if(controllers.down(0, GameControllers::Y))
    Serial.printf("%d\n",1);
  if(controllers.down(0, GameControllers::SELECT))
    Serial.printf("%d\n",2);
  if(controllers.down(0, GameControllers::START))
    Serial.printf("%d\n",3);
  if(controllers.down(0, GameControllers::UP))
    Serial.printf("%d\n",4);
  if(controllers.down(0, GameControllers::DOWN))
    Serial.printf("%d\n",5);
  if(controllers.down(0, GameControllers::LEFT))
    Serial.printf("%d\n",6);   
  if(controllers.down(0, GameControllers::RIGHT))
    Serial.printf("%d\n",7);
  if(controllers.down(0, GameControllers::A))
    Serial.printf("%d\n",8);
  if(controllers.down(0, GameControllers::X))
    Serial.printf("%d\n",9);
  if(controllers.down(0, GameControllers::L))
    Serial.printf("Left"); //ugly hack to trick the C# trick to trigger B or Y
  if(controllers.down(0, GameControllers::R))
    Serial.printf("Right");//ugly hack to trick the C# trick to trigger Y
  
  delay(50);
}
