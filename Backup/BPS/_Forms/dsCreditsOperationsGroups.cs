﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BPS._Forms {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsCreditsOperationsGroups : DataSet {
        
        private CreditsOperationsGroupsDataTable tableCreditsOperationsGroups;
        
        public dsCreditsOperationsGroups() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsCreditsOperationsGroups(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["CreditsOperationsGroups"] != null)) {
                    this.Tables.Add(new CreditsOperationsGroupsDataTable(ds.Tables["CreditsOperationsGroups"]));
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
        public CreditsOperationsGroupsDataTable CreditsOperationsGroups {
            get {
                return this.tableCreditsOperationsGroups;
            }
        }
        
        public override DataSet Clone() {
            dsCreditsOperationsGroups cln = ((dsCreditsOperationsGroups)(base.Clone()));
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
            if ((ds.Tables["CreditsOperationsGroups"] != null)) {
                this.Tables.Add(new CreditsOperationsGroupsDataTable(ds.Tables["CreditsOperationsGroups"]));
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
            this.tableCreditsOperationsGroups = ((CreditsOperationsGroupsDataTable)(this.Tables["CreditsOperationsGroups"]));
            if ((this.tableCreditsOperationsGroups != null)) {
                this.tableCreditsOperationsGroups.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsCreditsOperationsGroups";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsCreditsOperationsGroups.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableCreditsOperationsGroups = new CreditsOperationsGroupsDataTable();
            this.Tables.Add(this.tableCreditsOperationsGroups);
        }
        
        private bool ShouldSerializeCreditsOperationsGroups() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void CreditsOperationsGroupsRowChangeEventHandler(object sender, CreditsOperationsGroupsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CreditsOperationsGroupsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnGroupID;
            
            private DataColumn columnGroupDate;
            
            private DataColumn columnUserID;
            
            private DataColumn columnInstalmentSum;
            
            internal CreditsOperationsGroupsDataTable() : 
                    base("CreditsOperationsGroups") {
                this.InitClass();
            }
            
            internal CreditsOperationsGroupsDataTable(DataTable table) : 
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
            
            internal DataColumn GroupIDColumn {
                get {
                    return this.columnGroupID;
                }
            }
            
            internal DataColumn GroupDateColumn {
                get {
                    return this.columnGroupDate;
                }
            }
            
            internal DataColumn UserIDColumn {
                get {
                    return this.columnUserID;
                }
            }
            
            internal DataColumn InstalmentSumColumn {
                get {
                    return this.columnInstalmentSum;
                }
            }
            
            public CreditsOperationsGroupsRow this[int index] {
                get {
                    return ((CreditsOperationsGroupsRow)(this.Rows[index]));
                }
            }
            
            public event CreditsOperationsGroupsRowChangeEventHandler CreditsOperationsGroupsRowChanged;
            
            public event CreditsOperationsGroupsRowChangeEventHandler CreditsOperationsGroupsRowChanging;
            
            public event CreditsOperationsGroupsRowChangeEventHandler CreditsOperationsGroupsRowDeleted;
            
            public event CreditsOperationsGroupsRowChangeEventHandler CreditsOperationsGroupsRowDeleting;
            
            public void AddCreditsOperationsGroupsRow(CreditsOperationsGroupsRow row) {
                this.Rows.Add(row);
            }
            
            public CreditsOperationsGroupsRow AddCreditsOperationsGroupsRow(System.DateTime GroupDate, int UserID, System.Double InstalmentSum) {
                CreditsOperationsGroupsRow rowCreditsOperationsGroupsRow = ((CreditsOperationsGroupsRow)(this.NewRow()));
                rowCreditsOperationsGroupsRow.ItemArray = new object[] {
                        null,
                        GroupDate,
                        UserID,
                        InstalmentSum};
                this.Rows.Add(rowCreditsOperationsGroupsRow);
                return rowCreditsOperationsGroupsRow;
            }
            
            public CreditsOperationsGroupsRow FindByGroupID(int GroupID) {
                return ((CreditsOperationsGroupsRow)(this.Rows.Find(new object[] {
                            GroupID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                CreditsOperationsGroupsDataTable cln = ((CreditsOperationsGroupsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new CreditsOperationsGroupsDataTable();
            }
            
            internal void InitVars() {
                this.columnGroupID = this.Columns["GroupID"];
                this.columnGroupDate = this.Columns["GroupDate"];
                this.columnUserID = this.Columns["UserID"];
                this.columnInstalmentSum = this.Columns["InstalmentSum"];
            }
            
            private void InitClass() {
                this.columnGroupID = new DataColumn("GroupID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnGroupID);
                this.columnGroupDate = new DataColumn("GroupDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnGroupDate);
                this.columnUserID = new DataColumn("UserID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserID);
                this.columnInstalmentSum = new DataColumn("InstalmentSum", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnInstalmentSum);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnGroupID}, true));
                this.columnGroupID.AutoIncrement = true;
                this.columnGroupID.AllowDBNull = false;
                this.columnGroupID.ReadOnly = true;
                this.columnGroupID.Unique = true;
                this.columnGroupDate.AllowDBNull = false;
                this.columnInstalmentSum.AllowDBNull = false;
            }
            
            public CreditsOperationsGroupsRow NewCreditsOperationsGroupsRow() {
                return ((CreditsOperationsGroupsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new CreditsOperationsGroupsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(CreditsOperationsGroupsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.CreditsOperationsGroupsRowChanged != null)) {
                    this.CreditsOperationsGroupsRowChanged(this, new CreditsOperationsGroupsRowChangeEvent(((CreditsOperationsGroupsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.CreditsOperationsGroupsRowChanging != null)) {
                    this.CreditsOperationsGroupsRowChanging(this, new CreditsOperationsGroupsRowChangeEvent(((CreditsOperationsGroupsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.CreditsOperationsGroupsRowDeleted != null)) {
                    this.CreditsOperationsGroupsRowDeleted(this, new CreditsOperationsGroupsRowChangeEvent(((CreditsOperationsGroupsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.CreditsOperationsGroupsRowDeleting != null)) {
                    this.CreditsOperationsGroupsRowDeleting(this, new CreditsOperationsGroupsRowChangeEvent(((CreditsOperationsGroupsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveCreditsOperationsGroupsRow(CreditsOperationsGroupsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CreditsOperationsGroupsRow : DataRow {
            
            private CreditsOperationsGroupsDataTable tableCreditsOperationsGroups;
            
            internal CreditsOperationsGroupsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableCreditsOperationsGroups = ((CreditsOperationsGroupsDataTable)(this.Table));
            }
            
            public int GroupID {
                get {
                    return ((int)(this[this.tableCreditsOperationsGroups.GroupIDColumn]));
                }
                set {
                    this[this.tableCreditsOperationsGroups.GroupIDColumn] = value;
                }
            }
            
            public System.DateTime GroupDate {
                get {
                    return ((System.DateTime)(this[this.tableCreditsOperationsGroups.GroupDateColumn]));
                }
                set {
                    this[this.tableCreditsOperationsGroups.GroupDateColumn] = value;
                }
            }
            
            public int UserID {
                get {
                    try {
                        return ((int)(this[this.tableCreditsOperationsGroups.UserIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableCreditsOperationsGroups.UserIDColumn] = value;
                }
            }
            
            public System.Double InstalmentSum {
                get {
                    return ((System.Double)(this[this.tableCreditsOperationsGroups.InstalmentSumColumn]));
                }
                set {
                    this[this.tableCreditsOperationsGroups.InstalmentSumColumn] = value;
                }
            }
            
            public bool IsUserIDNull() {
                return this.IsNull(this.tableCreditsOperationsGroups.UserIDColumn);
            }
            
            public void SetUserIDNull() {
                this[this.tableCreditsOperationsGroups.UserIDColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CreditsOperationsGroupsRowChangeEvent : EventArgs {
            
            private CreditsOperationsGroupsRow eventRow;
            
            private DataRowAction eventAction;
            
            public CreditsOperationsGroupsRowChangeEvent(CreditsOperationsGroupsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public CreditsOperationsGroupsRow Row {
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