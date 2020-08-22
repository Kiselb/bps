﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BPS.BLL.Clients.DataSets {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsInterestRateList : DataSet {
        
        private InterestRatesDataTable tableInterestRates;
        
        public dsInterestRateList() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsInterestRateList(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["InterestRates"] != null)) {
                    this.Tables.Add(new InterestRatesDataTable(ds.Tables["InterestRates"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public InterestRatesDataTable InterestRates {
            get {
                return this.tableInterestRates;
            }
        }
        
        public override DataSet Clone() {
            dsInterestRateList cln = ((dsInterestRateList)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["InterestRates"] != null)) {
                this.Tables.Add(new InterestRatesDataTable(ds.Tables["InterestRates"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableInterestRates = ((InterestRatesDataTable)(this.Tables["InterestRates"]));
            if ((this.tableInterestRates != null)) {
                this.tableInterestRates.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsInterestRateList";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsInterestRateList.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableInterestRates = new InterestRatesDataTable();
            this.Tables.Add(this.tableInterestRates);
        }
        
        private bool ShouldSerializeInterestRates() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void InterestRatesRowChangeEventHandler(object sender, InterestRatesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class InterestRatesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnRateID;
            
            private DataColumn columnClientID;
            
            private DataColumn columnRequestTypeID;
            
            private DataColumn columnIsNormal;
            
            private DataColumn columnServiceCharge;
            
            private DataColumn columnMaxSum;
            
            internal InterestRatesDataTable() : 
                    base("InterestRates") {
                this.InitClass();
            }
            
            internal InterestRatesDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn RateIDColumn {
                get {
                    return this.columnRateID;
                }
            }
            
            internal DataColumn ClientIDColumn {
                get {
                    return this.columnClientID;
                }
            }
            
            internal DataColumn RequestTypeIDColumn {
                get {
                    return this.columnRequestTypeID;
                }
            }
            
            internal DataColumn IsNormalColumn {
                get {
                    return this.columnIsNormal;
                }
            }
            
            internal DataColumn ServiceChargeColumn {
                get {
                    return this.columnServiceCharge;
                }
            }
            
            internal DataColumn MaxSumColumn {
                get {
                    return this.columnMaxSum;
                }
            }
            
            public InterestRatesRow this[int index] {
                get {
                    return ((InterestRatesRow)(this.Rows[index]));
                }
            }
            
            public event InterestRatesRowChangeEventHandler InterestRatesRowChanged;
            
            public event InterestRatesRowChangeEventHandler InterestRatesRowChanging;
            
            public event InterestRatesRowChangeEventHandler InterestRatesRowDeleted;
            
            public event InterestRatesRowChangeEventHandler InterestRatesRowDeleting;
            
            public void AddInterestRatesRow(InterestRatesRow row) {
                this.Rows.Add(row);
            }
            
            public InterestRatesRow AddInterestRatesRow(int ClientID, int RequestTypeID, bool IsNormal, System.Double ServiceCharge, System.Double MaxSum) {
                InterestRatesRow rowInterestRatesRow = ((InterestRatesRow)(this.NewRow()));
                rowInterestRatesRow.ItemArray = new object[] {
                        null,
                        ClientID,
                        RequestTypeID,
                        IsNormal,
                        ServiceCharge,
                        MaxSum};
                this.Rows.Add(rowInterestRatesRow);
                return rowInterestRatesRow;
            }
            
            public InterestRatesRow FindByRateID(int RateID) {
                return ((InterestRatesRow)(this.Rows.Find(new object[] {
                            RateID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                InterestRatesDataTable cln = ((InterestRatesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new InterestRatesDataTable();
            }
            
            internal void InitVars() {
                this.columnRateID = this.Columns["RateID"];
                this.columnClientID = this.Columns["ClientID"];
                this.columnRequestTypeID = this.Columns["RequestTypeID"];
                this.columnIsNormal = this.Columns["IsNormal"];
                this.columnServiceCharge = this.Columns["ServiceCharge"];
                this.columnMaxSum = this.Columns["MaxSum"];
            }
            
            private void InitClass() {
                this.columnRateID = new DataColumn("RateID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnRateID);
                this.columnClientID = new DataColumn("ClientID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnClientID);
                this.columnRequestTypeID = new DataColumn("RequestTypeID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnRequestTypeID);
                this.columnIsNormal = new DataColumn("IsNormal", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsNormal);
                this.columnServiceCharge = new DataColumn("ServiceCharge", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnServiceCharge);
                this.columnMaxSum = new DataColumn("MaxSum", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnMaxSum);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnRateID}, true));
                this.columnRateID.AutoIncrement = true;
                this.columnRateID.AllowDBNull = false;
                this.columnRateID.ReadOnly = true;
                this.columnRateID.Unique = true;
                this.columnClientID.AllowDBNull = false;
                this.columnRequestTypeID.AllowDBNull = false;
                this.columnIsNormal.AllowDBNull = false;
                this.columnServiceCharge.AllowDBNull = false;
                this.columnMaxSum.AllowDBNull = false;
            }
            
            public InterestRatesRow NewInterestRatesRow() {
                return ((InterestRatesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new InterestRatesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(InterestRatesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.InterestRatesRowChanged != null)) {
                    this.InterestRatesRowChanged(this, new InterestRatesRowChangeEvent(((InterestRatesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.InterestRatesRowChanging != null)) {
                    this.InterestRatesRowChanging(this, new InterestRatesRowChangeEvent(((InterestRatesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.InterestRatesRowDeleted != null)) {
                    this.InterestRatesRowDeleted(this, new InterestRatesRowChangeEvent(((InterestRatesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.InterestRatesRowDeleting != null)) {
                    this.InterestRatesRowDeleting(this, new InterestRatesRowChangeEvent(((InterestRatesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveInterestRatesRow(InterestRatesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class InterestRatesRow : DataRow {
            
            private InterestRatesDataTable tableInterestRates;
            
            internal InterestRatesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableInterestRates = ((InterestRatesDataTable)(this.Table));
            }
            
            public int RateID {
                get {
                    return ((int)(this[this.tableInterestRates.RateIDColumn]));
                }
                set {
                    this[this.tableInterestRates.RateIDColumn] = value;
                }
            }
            
            public int ClientID {
                get {
                    return ((int)(this[this.tableInterestRates.ClientIDColumn]));
                }
                set {
                    this[this.tableInterestRates.ClientIDColumn] = value;
                }
            }
            
            public int RequestTypeID {
                get {
                    return ((int)(this[this.tableInterestRates.RequestTypeIDColumn]));
                }
                set {
                    this[this.tableInterestRates.RequestTypeIDColumn] = value;
                }
            }
            
            public bool IsNormal {
                get {
                    return ((bool)(this[this.tableInterestRates.IsNormalColumn]));
                }
                set {
                    this[this.tableInterestRates.IsNormalColumn] = value;
                }
            }
            
            public System.Double ServiceCharge {
                get {
                    return ((System.Double)(this[this.tableInterestRates.ServiceChargeColumn]));
                }
                set {
                    this[this.tableInterestRates.ServiceChargeColumn] = value;
                }
            }
            
            public System.Double MaxSum {
                get {
                    return ((System.Double)(this[this.tableInterestRates.MaxSumColumn]));
                }
                set {
                    this[this.tableInterestRates.MaxSumColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class InterestRatesRowChangeEvent : EventArgs {
            
            private InterestRatesRow eventRow;
            
            private DataRowAction eventAction;
            
            public InterestRatesRowChangeEvent(InterestRatesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public InterestRatesRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}