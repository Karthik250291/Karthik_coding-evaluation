using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganization
{
    internal abstract class Organization
    {
        private Position root;

        int empNo = 0;

        public Organization()
        {
            root = CreateOrganization();
        }

        protected abstract Position CreateOrganization();

        /**
         * hire the given person as an employee in the position that has that title
         * 
         * @param person
         * @param title
         * @return the newly filled position or empty if no position has that title
         */        

        public Position? Hire(Name person, String title)
        {
            AddNewEmployee(root, person, title);
            Display(root, person, title);
            return root;
        }

        private void AddNewEmployee(Position position, Name person, String title)
        {            
            if (position.GetTitle().Equals(title))
            {
                position.SetEmployee(new Employee(++empNo, new Name(person.GetFirst(), person.GetLast())));
            }

        }
        private void Display(Position position, Name name, string title)
        {                     
            foreach (Position pos in position.GetDirectReports())
            {
                AddNewEmployee(pos, name, title);
                Display(pos, name, title);
            }            
        }

        override public string ToString()
        {
            return PrintOrganization(root, "");
        }

        private string PrintOrganization(Position pos, string prefix)
        {
            StringBuilder sb = new StringBuilder(prefix + "+-" + pos.ToString() + "\n");
            foreach (Position p in pos.GetDirectReports())
            {
                sb.Append(PrintOrganization(p, prefix + "  "));
            }
            return sb.ToString();
        }
    }
}
