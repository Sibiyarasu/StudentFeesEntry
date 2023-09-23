using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
  public   class PartialModel
    {
        public StudentModel Create { get; set; }
        public List<FeesCheckBox> Checkbox { get; set; }
    }
}
