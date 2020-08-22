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
    public class dsPaymentsOrdersLinkHistory : DataSet {
        
        private ClientsDataTable tableClients;
        
        public dsPaymentsOrdersLinkHistory() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsPaymentsOrdersLinkHistory(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Clients"] != null)) {
                    this.Tables.Add(new ClientsDataTable(ds.Tables["Clients"]));
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
        public ClientsDataTable Clients {
            get {
                return this.tableClients;
            }
        }
        
        public override DataSet Clone() {
            dsPaymentsOrdersLinkHistory cln = ((dsPaymentsOrdersLinkHistory)(base.Clone()));
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
            if ((ds.Tables["Clients"] != null)) {
                this.Tables.Add(new ClientsDataTable(ds.Tables["Clients"]));
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
            this.tableClients = ((ClientsDataTable)(this.Tables["Clients"]));
            if ((this.tableClients != null)) {
                this.tableClients.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsPaymentsOrdersLinkHistory";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsPaymentsOrdersLinkHistory.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableClients = new ClientsDataTable();
            this.Tables.Add(this.tableClients);
        }
        
        private bool ShouldSerializeClients() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void ClientsRowChangeEventHandler(object sender, ClientsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ClientsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnClientID;
            
            private DataColumn columnClientName;
            
            private DataColumn columnMinCharge;
            
            private DataColumn columnMaxCharge;
            
            private DataColumn columnAvgCharge;
            
            internal ClientsDataTable() : 
                    base("Clients") {
                this.InitClass();
            }
            
            internal ClientsDataTable(DataTable table) : 
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
            
            internal DataColumn ClientIDColumn {
                get {
                    return this.columnClientID;
                }
            }
            
            internal DataColumn ClientNameColumn {
                get {
                    return this.columnClientName;
                }
            }
            
            internal DataColumn MinChargeColumn {
                get {
                    return this.columnMinCharge;
                }
            }
            
            internal DataColumn MaxChargeColumn {
                get {
                    return this.columnMaxCharge;
                }
            }
            
            internal DataColumn AvgChargeColumn {
                get {
                    return this.columnAvgCharge;
                }
            }
            
            public ClientsRow this[int index] {
                get {
                    return ((ClientsRow)(this.Rows[index]));
                }
            }
            
            public event ClientsRowChangeEventHandler ClientsRowChanged;
            
            public event ClientsRowChangeEventHandler ClientsRowChanging;
            
            public event ClientsRowChangeEventHandler ClientsRowDeleted;
            
            public event ClientsRowChangeEventHandler ClientsRowDeleting;
            
            public void AddClientsRow(ClientsRow row) {
                this.Rows.Add(row);
            }
            
            public ClientsRow AddClientsRow(string ClientName, System.Double MinCharge, System.Double MaxCharge, System.Double AvgCharge) {
                ClientsRow rowClientsRow = ((ClientsRow)(this.NewRow()));
                rowClientsRow.ItemArray = new object[] {
                        null,
                        ClientName,
                        MinCharge,
                        MaxCharge,
                        AvgCharge};
                this.Rows.Add(rowClientsRow);
                return rowClientsRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                ClientsDataTable cln = ((ClientsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new ClientsDataTable();
            }
            
            internal void InitVars() {
                this.columnClientID = this.Columns["ClientID"];
                this.columnClientName = this.Columns["ClientName"];
                this.columnMinCharge = this.Columns["MinCharge"];
                this.columnMaxCharge = this.Columns["MaxCharge"];
                this.columnAvgCharge = this.Columns["AvgCharge"];
            }
            
            private void InitClass() {
                this.columnClientID = new DataColumn("ClientID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnClientID);
                this.columnClientName = new DataColumn("ClientName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnClientName);
                this.columnMinCharge = new DataColumn("MinCharge", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnMinCharge);
                this.columnMaxCharge = new DataColumn("MaxCharge", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnMaxCharge);
                this.columnAvgCharge = new DataColumn("AvgCharge", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAvgCharge);
                this.columnClientID.AutoIncrement = true;
                this.columnClientID.AllowDBNull = false;
                this.columnClientID.ReadOnly = true;
                this.columnClientName.AllowDBNull = false;
                this.columnMinCharge.ReadOnly = true;
                this.columnMaxCharge.ReadOnly = true;
                this.columnAvgCharge.ReadOnly = true;
            }
            
            public ClientsRow NewClientsRow() {
                return ((ClientsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new ClientsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(ClientsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.ClientsRowChanged != null)) {
                    this.ClientsRowChanged(this, new ClientsRowChangeEvent(((ClientsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.ClientsRowChanging != null)) {
                    this.ClientsRowChanging(this, new ClientsRowChangeEvent(((ClientsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.ClientsRowDeleted != null)) {
                    this.ClientsRowDeleted(this, new ClientsRowChangeEvent(((ClientsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.ClientsRowDeleting != null)) {
                    this.ClientsRowDeleting(this, new ClientsRowChangeEvent(((ClientsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveClientsRow(ClientsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ClientsRow : DataRow {
            
            private ClientsDataTable tableClients;
            
            internal ClientsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableClients = ((ClientsDataTable)(this.Table));
            }
            
            public int ClientID {
                get {
                    return ((int)(this[this.tableClients.ClientIDColumn]));
                }
                set {
                    this[this.tableClients.ClientIDColumn] = value;
                }
            }
            
            public string ClientName {
                get {
                    return ((string)(this[this.tableClients.ClientNameColumn]));
                }
                set {
                    this[this.tableClients.ClientNameColumn] = value;
                }
            }
            
            public System.Double MinCharge {
                get {
                    try {
                        return ((System.Double)(this[this.tableClients.MinChargeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableClients.MinChargeColumn] = value;
                }
            }
            
            public System.Double MaxCharge {
                get {
                    try {
                        return ((System.Double)(this[this.tableClients.MaxChargeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableClients.MaxChargeColumn] = value;
                }
            }
            
            public System.Double AvgCharge {
                get {
                    try {
                        return ((System.Double)(this[this.tableClients.AvgChargeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableClients.AvgChargeColumn] = value;
                }
            }
            
            public bool IsMinChargeNull() {
                return this.IsNull(this.tableClients.MinChargeColumn);
            }
            
            public void SetMinChargeNull() {
                this[this.tableClients.MinChargeColumn] = System.Convert.DBNull;
            }
            
            public bool IsMaxChargeNull() {
                return this.IsNull(this.tableClients.MaxChargeColumn);
            }
            
            public void SetMaxChargeNull() {
                this[this.tableClients.MaxChargeColumn] = System.Convert.DBNull;
            }
            
            public bool IsAvgChargeNull() {
                return this.IsNull(this.tableClients.AvgChargeColumn);
            }
            
            public void SetAvgChargeNull() {
                this[this.tableClients.AvgChargeColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ClientsRowChangeEvent : EventArgs {
            
            private ClientsRow eventRow;
            
            private DataRowAction eventAction;
            
            public ClientsRowChangeEvent(ClientsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public ClientsRow Row {
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