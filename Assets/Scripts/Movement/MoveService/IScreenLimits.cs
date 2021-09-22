using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IScreenLimits
{
    void SetNewCameraLimits(Camera newCam);
    void MovementLimits();

}
