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
    public class dsBalanceAccountsState : DataSet {
        
        private BalanceAccountsByTypeSummaryDataTable tableBalanceAccountsByTypeSummary;
        
        public dsBalanceAccountsState() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsBalanceAccountsState(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["BalanceAccountsByTypeSummary"] != null)) {
                    this.Tables.Add(new BalanceAccountsByTypeSummaryDataTable(ds.Tables["BalanceAccountsByTypeSummary"]));
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
        public BalanceAccountsByTypeSummaryDataTable BalanceAccountsByTypeSummary {
            get {
                return this.tableBalanceAccountsByTypeSummary;
            }
        }
        
        public override DataSet Clone() {
            dsBalanceAccountsState cln = ((dsBalanceAccountsState)(base.Clone()));
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
            if ((ds.Tables["BalanceAccountsByTypeSummary"] != null)) {
                this.Tables.Add(new BalanceAccountsByTypeSummaryDataTable(ds.Tables["BalanceAccountsByTypeSummary"]));
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
            this.tableBalanceAccountsByTypeSummary = ((BalanceAccountsByTypeSummaryDataTable)(this.Tables["BalanceAccountsByTypeSummary"]));
            if ((this.tableBalanceAccountsByTypeSummary != null)) {
                this.tableBalanceAccountsByTypeSummary.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsBalanceAccountsState";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsBalanceAccountsState.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableBalanceAccountsByTypeSummary = new BalanceAccountsByTypeSummaryDataTable();
            this.Tables.Add(this.tableBalanceAccountsByTypeSummary);
        }
        
        private bool ShouldSerializeBalanceAccountsByTypeSummary() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void BalanceAccountsByTypeSummaryRowChangeEventHandler(object sender, BalanceAccountsByTypeSummaryRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BalanceAccountsByTypeSummaryDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnAccountTypeID;
            
            private DataColumn columnTypeName;
            
            private DataColumn columnCurrencyID;
            
            private DataColumn columnSumSaldo;
            
            private DataColumn columnSumSumWaited;
            
            private DataColumn columnSumSumReserved;
            
            private DataColumn columnSumSumFree;
            
            internal BalanceAccountsByTypeSummaryDataTable() : 
                    base("BalanceAccountsByTypeSummary") {
                this.InitClass();
            }
            
            internal BalanceAccountsByTypeSummaryDataTable(DataTable table) : 
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
            
            internal DataColumn AccountTypeIDColumn {
                get {
                    return this.columnAccountTypeID;
                }
            }
            
            internal DataColumn TypeNameColumn {
                get {
                    return this.columnTypeName;
                }
            }
            
            internal DataColumn CurrencyIDColumn {
                get {
                    return this.columnCurrencyID;
                }
            }
            
            internal DataColumn SumSaldoColumn {
                get {
                    return this.columnSumSaldo;
                }
            }
            
            internal DataColumn SumSumWaitedColumn {
                get {
                    return this.columnSumSumWaited;
                }
            }
            
            internal DataColumn SumSumReservedColumn {
                get {
                    return this.columnSumSumReserved;
                }
            }
            
            internal DataColumn SumSumFreeColumn {
                get {
                    return this.columnSumSumFree;
                }
            }
            
            public BalanceAccountsByTypeSummaryRow this[int index] {
                get {
                    return ((BalanceAccountsByTypeSummaryRow)(this.Rows[index]));
                }
            }
            
            public event BalanceAccountsByTypeSummaryRowChangeEventHandler BalanceAccountsByTypeSummaryRowChanged;
            
            public event BalanceAccountsByTypeSummaryRowChangeEventHandler BalanceAccountsByTypeSummaryRowChanging;
            
            public event BalanceAccountsByTypeSummaryRowChangeEventHandler BalanceAccountsByTypeSummaryRowDeleted;
            
            public event BalanceAccountsByTypeSummaryRowChangeEventHandler BalanceAccountsByTypeSummaryRowDeleting;
            
            public void AddBalanceAccountsByTypeSummaryRow(BalanceAccountsByTypeSummaryRow row) {
                this.Rows.Add(row);
            }
            
            public BalanceAccountsByTypeSummaryRow AddBalanceAccountsByTypeSummaryRow(string TypeName, string CurrencyID, System.Double SumSaldo, System.Double SumSumWaited, System.Double SumSumReserved, System.Double SumSumFree) {
                BalanceAccountsByTypeSummaryRow rowBalanceAccountsByTypeSummaryRow = ((BalanceAccountsByTypeSummaryRow)(this.NewRow()));
                rowBalanceAccountsByTypeSummaryRow.ItemArray = new object[] {
                        null,
                        TypeName,
                        CurrencyID,
                        SumSaldo,
                        SumSumWaited,
                        SumSumReserved,
                        SumSumFree};
                this.Rows.Add(rowBalanceAccountsByTypeSummaryRow);
                return rowBalanceAccountsByTypeSummaryRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                BalanceAccountsByTypeSummaryDataTable cln = ((BalanceAccountsByTypeSummaryDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new BalanceAccountsByTypeSummaryDataTable();
            }
            
            internal void InitVars() {
                this.columnAccountTypeID = this.Columns["AccountTypeID"];
                this.columnTypeName = this.Columns["TypeName"];
                this.columnCurrencyID = this.Columns["CurrencyID"];
                this.columnSumSaldo = this.Columns["SumSaldo"];
                this.columnSumSumWaited = this.Columns["SumSumWaited"];
                this.columnSumSumReserved = this.Columns["SumSumReserved"];
                this.columnSumSumFree = this.Columns["SumSumFree"];
            }
            
            private void InitClass() {
                this.columnAccountTypeID = new DataColumn("AccountTypeID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAccountTypeID);
                this.columnTypeName = new DataColumn("TypeName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnTypeName);
                this.columnCurrencyID = new DataColumn("CurrencyID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrencyID);
                this.columnSumSaldo = new DataColumn("SumSaldo", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSumSaldo);
                this.columnSumSumWaited = new DataColumn("SumSumWaited", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSumSumWaited);
                this.columnSumSumReserved = new DataColumn("SumSumReserved", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSumSumReserved);
                this.columnSumSumFree = new DataColumn("SumSumFree", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnSumSumFree);
                this.columnAccountTypeID.AutoIncrement = true;
                this.columnAccountTypeID.AllowDBNull = false;
                this.columnAccountTypeID.ReadOnly = true;
                this.columnTypeName.AllowDBNull = false;
                this.columnCurrencyID.AllowDBNull = false;
                this.columnSumSaldo.ReadOnly = true;
                this.columnSumSumWaited.ReadOnly = true;
                this.columnSumSumReserved.ReadOnly = true;
                this.columnSumSumFree.ReadOnly = true;
            }
            
            public BalanceAccountsByTypeSummaryRow NewBalanceAccountsByTypeSummaryRow() {
                return ((BalanceAccountsByTypeSummaryRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new BalanceAccountsByTypeSummaryRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(BalanceAccountsByTypeSummaryRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.BalanceAccountsByTypeSummaryRowChanged != null)) {
                    this.BalanceAccountsByTypeSummaryRowChanged(this, new BalanceAccountsByTypeSummaryRowChangeEvent(((BalanceAccountsByTypeSummaryRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.BalanceAccountsByTypeSummaryRowChanging != null)) {
                    this.BalanceAccountsByTypeSummaryRowChanging(this, new BalanceAccountsByTypeSummaryRowChangeEvent(((BalanceAccountsByTypeSummaryRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.BalanceAccountsByTypeSummaryRowDeleted != null)) {
                    this.BalanceAccountsByTypeSummaryRowDeleted(this, new BalanceAccountsByTypeSummaryRowChangeEvent(((BalanceAccountsByTypeSummaryRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.BalanceAccountsByTypeSummaryRowDeleting != null)) {
                    this.BalanceAccountsByTypeSummaryRowDeleting(this, new BalanceAccountsByTypeSummaryRowChangeEvent(((BalanceAccountsByTypeSummaryRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveBalanceAccountsByTypeSummaryRow(BalanceAccountsByTypeSummaryRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BalanceAccountsByTypeSummaryRow : DataRow {
            
            private BalanceAccountsByTypeSummaryDataTable tableBalanceAccountsByTypeSummary;
            
            internal BalanceAccountsByTypeSummaryRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableBalanceAccountsByTypeSummary = ((BalanceAccountsByTypeSummaryDataTable)(this.Table));
            }
            
            public int AccountTypeID {
                get {
                    return ((int)(this[this.tableBalanceAccountsByTypeSummary.AccountTypeIDColumn]));
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.AccountTypeIDColumn] = value;
                }
            }
            
            public string TypeName {
                get {
                    return ((string)(this[this.tableBalanceAccountsByTypeSummary.TypeNameColumn]));
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.TypeNameColumn] = value;
                }
            }
            
            public string CurrencyID {
                get {
                    return ((string)(this[this.tableBalanceAccountsByTypeSummary.CurrencyIDColumn]));
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.CurrencyIDColumn] = value;
                }
            }
            
            public System.Double SumSaldo {
                get {
                    try {
                        return ((System.Double)(this[this.tableBalanceAccountsByTypeSummary.SumSaldoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.SumSaldoColumn] = value;
                }
            }
            
            public System.Double SumSumWaited {
                get {
                    try {
                        return ((System.Double)(this[this.tableBalanceAccountsByTypeSummary.SumSumWaitedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.SumSumWaitedColumn] = value;
                }
            }
            
            public System.Double SumSumReserved {
                get {
                    try {
                        return ((System.Double)(this[this.tableBalanceAccountsByTypeSummary.SumSumReservedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.SumSumReservedColumn] = value;
                }
            }
            
            public System.Double SumSumFree {
                get {
                    try {
                        return ((System.Double)(this[this.tableBalanceAccountsByTypeSummary.SumSumFreeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableBalanceAccountsByTypeSummary.SumSumFreeColumn] = value;
                }
            }
            
            public bool IsSumSaldoNull() {
                return this.IsNull(this.tableBalanceAccountsByTypeSummary.SumSaldoColumn);
            }
            
            public void SetSumSaldoNull() {
                this[this.tableBalanceAccountsByTypeSummary.SumSaldoColumn] = System.Convert.DBNull;
            }
            
            public bool IsSumSumWaitedNull() {
                return this.IsNull(this.tableBalanceAccountsByTypeSummary.SumSumWaitedColumn);
            }
            
            public void SetSumSumWaitedNull() {
                this[this.tableBalanceAccountsByTypeSummary.SumSumWaitedColumn] = System.Convert.DBNull;
            }
            
            public bool IsSumSumReservedNull() {
                return this.IsNull(this.tableBalanceAccountsByTypeSummary.SumSumReservedColumn);
            }
            
            public void SetSumSumReservedNull() {
                this[this.tableBalanceAccountsByTypeSummary.SumSumReservedColumn] = System.Convert.DBNull;
            }
            
            public bool IsSumSumFreeNull() {
                return this.IsNull(this.tableBalanceAccountsByTypeSummary.SumSumFreeColumn);
            }
            
            public void SetSumSumFreeNull() {
                this[this.tableBalanceAccountsByTypeSummary.SumSumFreeColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class BalanceAccountsByTypeSummaryRowChangeEvent : EventArgs {
            
            private BalanceAccountsByTypeSummaryRow eventRow;
            
            private DataRowAction eventAction;
            
            public BalanceAccountsByTypeSummaryRowChangeEvent(BalanceAccountsByTypeSummaryRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public BalanceAccountsByTypeSummaryRow Row {
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
