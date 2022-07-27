#ifndef HAPTICCONTROL_H
#define HAPTICCONTROL_H

#include "Haptic_DRV2605.h"

class HapticControl {
 private:
  Haptic_DRV2605 drv;

 public:
  HapticControl();
  uint8_t devStatus;  // return status after init device (0 = success, !0 = error)
  int setup();
  int setWaveform(uint8_t slot, uint8_t wave);
  int goWait(void);
  int go(void);
  void demo();

};

HapticControl::HapticControl() { 
  drv = Haptic_DRV2605(); 
  }

int HapticControl::setup() {
  if (drv.begin() != HAPTIC_SUCCESS) {
    devStatus = 1;
    Serial.println("Haptic: Driver Error: DRV2605L Device not found - check your I2C connections.");
  } else {
	//   Serial.println("Haptic: DeviceID = DRV2605L @ Address 0x5A was found!");
    drv.setActuatorType(LRA);  	// select an actuator type (LRA or ERM)
    drv.setMode(REGISTER_MODE);  // haptic effects triggered by I2C register write
    devStatus = 0;
  }
  return devStatus;
}


int HapticControl::setWaveform(uint8_t slot, uint8_t wave){
  return drv.setWaveform(slot, wave);
}

int HapticControl::goWait(void){
  return drv.goWait();
}

int HapticControl::go(void){
  return drv.go();
}

void HapticControl::demo(){
  int waveform = 0;
  int waveforms_max = drv.getWaveforms();

  for(int i = 0; i < waveforms_max; i++){
    Serial.print("Waveform #");                   // which waveform
    Serial.println(waveform);
    drv.setWaveform(0, waveform);              // set the first sequence
    drv.setWaveform(1, 0);                     // end the sequence
    drv.goWait();				                      // play the waveform
    delay(200);					                          // wait for a while
    waveform++;					                          // next waveform
    if (waveform >= waveforms_max) waveform = 0;  // loop through all the waveforms
  }
}

#endif