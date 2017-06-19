using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hikari.net.aspxtests.DataBaseUtilities.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Autoincrement : Attribute
    {
    }
}
