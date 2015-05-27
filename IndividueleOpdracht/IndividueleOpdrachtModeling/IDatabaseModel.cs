using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividueleOpdracht.Models
{
    interface IDatabaseModel
    {
        string Id();

        IDatabaseModel Create();
        IDatabaseModel Read();
        IDatabaseModel Update();
        IDatabaseModel Destroy();

    }
}
