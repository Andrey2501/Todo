using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Core
{
    public class TodoCreateModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
