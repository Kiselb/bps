﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.0
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
    public class dsLocksList : DataSet {
        
        private LocksDataTable tableLocks;
        
        public dsLocksList() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsLocksList(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Locks"] != null)) {
                    this.Tables.Add(new LocksDataTable(ds.Tables["Locks"]));
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
        public LocksDataTable Locks {
            get {
                return this.tableLocks;
            }
        }
        
        public override DataSet Clone() {
            dsLocksList cln = ((dsLocksList)(base.Clone()));
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
            if ((ds.Tables["Locks"] != null)) {
                this.Tables.Add(new LocksDataTable(ds.Tables["Locks"]));
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
            this.tableLocks = ((LocksDataTable)(this.Tables["Locks"]));
            if ((this.tableLocks != null)) {
                this.tableLocks.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsLocksList";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsLocksList.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableLocks = new LocksDataTable();
            this.Tables.Add(this.tableLocks);
        }
        
        private bool ShouldSerializeLocks() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void LocksRowChangeEventHandler(object sender, LocksRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class LocksDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnEntityTypeID;
            
            private DataColumn columnEntityID;
            
            private DataColumn columnUserName;
            
            private DataColumn columnUserID;
            
            private DataColumn columnEntityTypeName;
            
            internal LocksDataTable() : 
                    base("Locks") {
                this.InitClass();
            }
            
            internal LocksDataTable(DataTable table) : 
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
            
            internal DataColumn EntityTypeIDColumn {
                get {
                    return this.columnEntityTypeID;
                }
            }
            
            internal DataColumn EntityIDColumn {
                get {
                    return this.columnEntityID;
                }
            }
            
            internal DataColumn UserNameColumn {
                get {
                    return this.columnUserName;
                }
            }
            
            internal DataColumn UserIDColumn {
                get {
                    return this.columnUserID;
                }
            }
            
            internal DataColumn EntityTypeNameColumn {
                get {
                    return this.columnEntityTypeName;
                }
            }
            
            public LocksRow this[int index] {
                get {
                    return ((LocksRow)(this.Rows[index]));
                }
            }
            
            public event LocksRowChangeEventHandler LocksRowChanged;
            
            public event LocksRowChangeEventHandler LocksRowChanging;
            
            public event LocksRowChangeEventHandler LocksRowDeleted;
            
            public event LocksRowChangeEventHandler LocksRowDeleting;
            
            public void AddLocksRow(LocksRow row) {
                this.Rows.Add(row);
            }
            
            public LocksRow AddLocksRow(int EntityTypeID, int EntityID, string UserName, string EntityTypeName) {
                LocksRow rowLocksRow = ((LocksRow)(this.NewRow()));
                rowLocksRow.ItemArray = new object[] {
                        EntityTypeID,
                        EntityID,
                        UserName,
                        null,
                        EntityTypeName};
                this.Rows.Add(rowLocksRow);
                return rowLocksRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                LocksDataTable cln = ((LocksDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new LocksDataTable();
            }
            
            internal void InitVars() {
                this.columnEntityTypeID = this.Columns["EntityTypeID"];
                this.columnEntityID = this.Columns["EntityID"];
                this.columnUserName = this.Columns["UserName"];
                this.columnUserID = this.Columns["UserID"];
                this.columnEntityTypeName = this.Columns["EntityTypeName"];
            }
            
            private void InitClass() {
                this.columnEntityTypeID = new DataColumn("EntityTypeID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnEntityTypeID);
                this.columnEntityID = new DataColumn("EntityID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnEntityID);
                this.columnUserName = new DataColumn("UserName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserName);
                this.columnUserID = new DataColumn("UserID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserID);
                this.columnEntityTypeName = new DataColumn("EntityTypeName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnEntityTypeName);
                this.columnEntityTypeID.AllowDBNull = false;
                this.columnEntityID.AllowDBNull = false;
                this.columnUserName.AllowDBNull = false;
                this.columnUserID.AutoIncrement = true;
                this.columnUserID.AllowDBNull = false;
                this.columnUserID.ReadOnly = true;
                this.columnEntityTypeName.AllowDBNull = false;
            }
            
            public LocksRow NewLocksRow() {
                return ((LocksRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new LocksRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(LocksRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.LocksRowChanged != null)) {
                    this.LocksRowChanged(this, new LocksRowChangeEvent(((LocksRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.LocksRowChanging != null)) {
                    this.LocksRowChanging(this, new LocksRowChangeEvent(((LocksRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.LocksRowDeleted != null)) {
                    this.LocksRowDeleted(this, new LocksRowChangeEvent(((LocksRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.LocksRowDeleting != null)) {
                    this.LocksRowDeleting(this, new LocksRowChangeEvent(((LocksRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveLocksRow(LocksRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class LocksRow : DataRow {
            
            private LocksDataTable tableLocks;
            
            internal LocksRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableLocks = ((LocksDataTable)(this.Table));
            }
            
            public int EntityTypeID {
                get {
                    return ((int)(this[this.tableLocks.EntityTypeIDColumn]));
                }
                set {
                    this[this.tableLocks.EntityTypeIDColumn] = value;
                }
            }
            
            public int EntityID {
                get {
                    return ((int)(this[this.tableLocks.EntityIDColumn]));
                }
                set {
                    this[this.tableLocks.EntityIDColumn] = value;
                }
            }
            
            public string UserName {
                get {
                    return ((string)(this[this.tableLocks.UserNameColumn]));
                }
                set {
                    this[this.tableLocks.UserNameColumn] = value;
                }
            }
            
            public int UserID {
                get {
                    return ((int)(this[this.tableLocks.UserIDColumn]));
                }
                set {
                    this[this.tableLocks.UserIDColumn] = value;
                }
            }
            
            public string EntityTypeName {
                get {
                    return ((string)(this[this.tableLocks.EntityTypeNameColumn]));
                }
                set {
                    this[this.tableLocks.EntityTypeNameColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class LocksRowChangeEvent : EventArgs {
            
            private LocksRow eventRow;
            
            private DataRowAction eventAction;
            
            public LocksRowChangeEvent(LocksRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public LocksRow Row {
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
