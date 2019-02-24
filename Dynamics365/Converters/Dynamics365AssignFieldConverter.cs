﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using ScottLane.DataTidy.Core;

namespace ScottLane.DataTidy.Dynamics365
{
    public class Dynamics365AssignFieldConverter : Dynamics365FieldConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!string.IsNullOrEmpty((string)value))
            {
                IDynamics365AssignDataDestinationFieldsProvider provider = (IDynamics365AssignDataDestinationFieldsProvider)context.Instance;
                List<Field> fields = provider.GetDynamics365AssignDataDestinationFields();
                string logicalName = Regex.Match((string)value, CoreUtility.FieldMatchPattern).Groups[1].Value;
                return fields.FirstOrDefault(field => ((Dynamics365Field)field).LogicalName == logicalName);
            }

            return null;
        }

        /// <summary>
        /// Gets a list of DataDestination Field objects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The list of DataDestination Field items.</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            IDynamics365AssignDataDestinationFieldsProvider provider = (IDynamics365AssignDataDestinationFieldsProvider)context.Instance;
            return new StandardValuesCollection(provider.GetDynamics365AssignDataDestinationFields());
        }
    }
}
