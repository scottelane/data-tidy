﻿using System.Collections.Generic;
using System.ComponentModel;
using ScottLane.DataTidy.Core;

namespace ScottLane.DataTidy.Dynamics365
{
    /// <summary>
    /// Gets a value from a Dynamics 365 data source.
    /// </summary>
    public class Dynamics365SetStateDataSourceValue : Dynamics365DataSourceValue, IDynamics365SetStateDataDestinationFieldsProvider
    {
        [TypeConverter(typeof(Dynamics365SetStateFieldConverter))]
        public override Field DestinationField
        {
            get { return base.DestinationField; }
            set { base.DestinationField = value; }
        }

        /// <summary>
        /// Initialises a new instance of the Dynamics365SetStateDataSourceValue class with the specified parent operation.
        /// </summary>
        /// <param name="parentOperation">The parent operation.</param>
        public Dynamics365SetStateDataSourceValue(IOperation parentOperation) : base(parentOperation)
        { }

        public List<Field> GetDynamics365SetStateDataDestinationFields()
        {
            return ((IDynamics365SetStateDataDestinationFieldsProvider)Parent).GetDynamics365SetStateDataDestinationFields();
        }
    }
}
