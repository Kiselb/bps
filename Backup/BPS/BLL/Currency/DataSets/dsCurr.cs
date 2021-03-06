﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BPS.BLL.Currency.DataSets {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsCurr : DataSet {
        
        private CurrenciesDataTable tableCurrencies;
        
        public dsCurr() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsCurr(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Currencies"] != null)) {
                    this.Tables.Add(new CurrenciesDataTable(ds.Tables["Currencies"]));
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
        public CurrenciesDataTable Currencies {
            get {
                return this.tableCurrencies;
            }
        }
        
        public override DataSet Clone() {
            dsCurr cln = ((dsCurr)(base.Clone()));
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
            if ((ds.Tables["Currencies"] != null)) {
                this.Tables.Add(new CurrenciesDataTable(ds.Tables["Currencies"]));
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
            this.tableCurrencies = ((CurrenciesDataTable)(this.Tables["Currencies"]));
            if ((this.tableCurrencies != null)) {
                this.tableCurrencies.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsCurr";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsCurr.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableCurrencies = new CurrenciesDataTable();
            this.Tables.Add(this.tableCurrencies);
        }
        
        private bool ShouldSerializeCurrencies() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void CurrenciesRowChangeEventHandler(object sender, CurrenciesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CurrenciesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnCurrencyID;
            
            private DataColumn columnCurrencyName;
            
            private DataColumn columnCurrencyRate;
            
            private DataColumn columnIsBase;
            
            internal CurrenciesDataTable() : 
                    base("Currencies") {
                this.InitClass();
            }
            
            internal CurrenciesDataTable(DataTable table) : 
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
            
            internal DataColumn CurrencyIDColumn {
                get {
                    return this.columnCurrencyID;
                }
            }
            
            internal DataColumn CurrencyNameColumn {
                get {
                    return this.columnCurrencyName;
                }
            }
            
            internal DataColumn CurrencyRateColumn {
                get {
                    return this.columnCurrencyRate;
                }
            }
            
            internal DataColumn IsBaseColumn {
                get {
                    return this.columnIsBase;
                }
            }
            
            public CurrenciesRow this[int index] {
                get {
                    return ((CurrenciesRow)(this.Rows[index]));
                }
            }
            
            public event CurrenciesRowChangeEventHandler CurrenciesRowChanged;
            
            public event CurrenciesRowChangeEventHandler CurrenciesRowChanging;
            
            public event CurrenciesRowChangeEventHandler CurrenciesRowDeleted;
            
            public event CurrenciesRowChangeEventHandler CurrenciesRowDeleting;
            
            public void AddCurrenciesRow(CurrenciesRow row) {
                this.Rows.Add(row);
            }
            
            public CurrenciesRow AddCurrenciesRow(string CurrencyID, string CurrencyName, System.Double CurrencyRate, bool IsBase) {
                CurrenciesRow rowCurrenciesRow = ((CurrenciesRow)(this.NewRow()));
                rowCurrenciesRow.ItemArray = new object[] {
                        CurrencyID,
                        CurrencyName,
                        CurrencyRate,
                        IsBase};
                this.Rows.Add(rowCurrenciesRow);
                return rowCurrenciesRow;
            }
            
            public CurrenciesRow FindByCurrencyID(string CurrencyID) {
                return ((CurrenciesRow)(this.Rows.Find(new object[] {
                            CurrencyID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                CurrenciesDataTable cln = ((CurrenciesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new CurrenciesDataTable();
            }
            
            internal void InitVars() {
                this.columnCurrencyID = this.Columns["CurrencyID"];
                this.columnCurrencyName = this.Columns["CurrencyName"];
                this.columnCurrencyRate = this.Columns["CurrencyRate"];
                this.columnIsBase = this.Columns["IsBase"];
            }
            
            private void InitClass() {
                this.columnCurrencyID = new DataColumn("CurrencyID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrencyID);
                this.columnCurrencyName = new DataColumn("CurrencyName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrencyName);
                this.columnCurrencyRate = new DataColumn("CurrencyRate", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrencyRate);
                this.columnIsBase = new DataColumn("IsBase", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsBase);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnCurrencyID}, true));
                this.columnCurrencyID.AllowDBNull = false;
                this.columnCurrencyID.Unique = true;
                this.columnCurrencyName.AllowDBNull = false;
                this.columnCurrencyRate.AllowDBNull = false;
                this.columnIsBase.DefaultValue = false;
            }
            
            public CurrenciesRow NewCurrenciesRow() {
                return ((CurrenciesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new CurrenciesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(CurrenciesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.CurrenciesRowChanged != null)) {
                    this.CurrenciesRowChanged(this, new CurrenciesRowChangeEvent(((CurrenciesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.CurrenciesRowChanging != null)) {
                    this.CurrenciesRowChanging(this, new CurrenciesRowChangeEvent(((CurrenciesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.CurrenciesRowDeleted != null)) {
                    this.CurrenciesRowDeleted(this, new CurrenciesRowChangeEvent(((CurrenciesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.CurrenciesRowDeleting != null)) {
                    this.CurrenciesRowDeleting(this, new CurrenciesRowChangeEvent(((CurrenciesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveCurrenciesRow(CurrenciesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CurrenciesRow : DataRow {
            
            private CurrenciesDataTable tableCurrencies;
            
            internal CurrenciesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableCurrencies = ((CurrenciesDataTable)(this.Table));
            }
            
            public string CurrencyID {
                get {
                    return ((string)(this[this.tableCurrencies.CurrencyIDColumn]));
                }
                set {
                    this[this.tableCurrencies.CurrencyIDColumn] = value;
                }
            }
            
            public string CurrencyName {
                get {
                    return ((string)(this[this.tableCurrencies.CurrencyNameColumn]));
                }
                set {
                    this[this.tableCurrencies.CurrencyNameColumn] = value;
                }
            }
            
            public System.Double CurrencyRate {
                get {
                    return ((System.Double)(this[this.tableCurrencies.CurrencyRateColumn]));
                }
                set {
                    this[this.tableCurrencies.CurrencyRateColumn] = value;
                }
            }
            
            public bool IsBase {
                get {
                    try {
                        return ((bool)(this[this.tableCurrencies.IsBaseColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableCurrencies.IsBaseColumn] = value;
                }
            }
            
            public bool IsIsBaseNull() {
                return this.IsNull(this.tableCurrencies.IsBaseColumn);
            }
            
            public void SetIsBaseNull() {
                this[this.tableCurrencies.IsBaseColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class CurrenciesRowChangeEvent : EventArgs {
            
            private CurrenciesRow eventRow;
            
            private DataRowAction eventAction;
            
            public CurrenciesRowChangeEvent(CurrenciesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public CurrenciesRow Row {
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
