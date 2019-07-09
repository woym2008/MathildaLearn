using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IInputService
{
    InputData KeyData
    {
        get;
    }

    void Update(float dt);
}
