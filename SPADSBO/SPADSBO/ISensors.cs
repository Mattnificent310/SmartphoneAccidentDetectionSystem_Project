using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    interface ISensors
    {
        List<Sensors> SensorStatus(Sensors sensor);
        bool ResetSensor(Sensors sensor);
        Sensors Calibrate(Sensors sensor);

    }
}
