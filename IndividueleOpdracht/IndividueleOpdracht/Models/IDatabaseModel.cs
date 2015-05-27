using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividueleOpdracht.Models
{
    public interface IDatabaseModel
    {
        string Id { get; set; }

        bool Create();

        bool Read();

        bool Update();

        bool Destroy();
    }
}
