using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabusView : MonoBehaviour
{
    private BabusStatus _status;
    public void Setup(BabusStatus status)
    {
        _status = status;
    }
}
