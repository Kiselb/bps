﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BPS.BLL.Orgs.DataSets {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsOrgsAccount : DataSet {
        
        private OrgsAccountsDataTable tableOrgsAccounts;
        
        public dsOrgsAccount() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsOrgsAccount(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["OrgsAccounts"] != null)) {
                    this.Tables.Add(new OrgsAccountsDataTable(ds.Tables["OrgsAccounts"]));
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
        public OrgsAccountsDataTable OrgsAccounts {
            get {
                return this.tableOrgsAccounts;
            }
        }
        
        public override DataSet Clone() {
            dsOrgsAccount cln = ((dsOrgsAccount)(base.Clone()));
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
            if ((ds.Tables["OrgsAccounts"] != null)) {
                this.Tables.Add(new OrgsAccountsDataTable(ds.Tables["OrgsAccounts"]));
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
            this.tableOrgsAccounts = ((OrgsAccountsDataTable)(this.Tables["OrgsAccounts"]));
            if ((this.tableOrgsAccounts != null)) {
                this.tableOrgsAccounts.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsOrgsAccount";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsOrgsAccount.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOrgsAccounts = new OrgsAccountsDataTable();
            this.Tables.Add(this.tableOrgsAccounts);
        }
        
        private bool ShouldSerializeOrgsAccounts() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void OrgsAccountsRowChangeEventHandler(object sender, OrgsAccountsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsAccountsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnOrgsAccountsID;
            
            private DataColumn columnAccountID;
            
            private DataColumn columnOrgID;
            
            private DataColumn columnRAccount;
            
            private DataColumn columnBankID;
            
            private DataColumn columnCurrencyID;
            
            private DataColumn columnOrgName;
            
            internal OrgsAccountsDataTable() : 
                    base("OrgsAccounts") {
                this.InitClass();
            }
            
            internal OrgsAccountsDataTable(DataTable table) : 
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
            
            internal DataColumn OrgsAccountsIDColumn {
                get {
                    return this.columnOrgsAccountsID;
                }
            }
            
            internal DataColumn AccountIDColumn {
                get {
                    return this.columnAccountID;
                }
            }
            
            internal DataColumn OrgIDColumn {
                get {
                    return this.columnOrgID;
                }
            }
            
            internal DataColumn RAccountColumn {
                get {
                    return this.columnRAccount;
                }
            }
            
            internal DataColumn BankIDColumn {
                get {
                    return this.columnBankID;
                }
            }
            
            internal DataColumn CurrencyIDColumn {
                get {
                    return this.columnCurrencyID;
                }
            }
            
            internal DataColumn OrgNameColumn {
                get {
                    return this.columnOrgName;
                }
            }
            
            public OrgsAccountsRow this[int index] {
                get {
                    return ((OrgsAccountsRow)(this.Rows[index]));
                }
            }
            
            public event OrgsAccountsRowChangeEventHandler OrgsAccountsRowChanged;
            
            public event OrgsAccountsRowChangeEventHandler OrgsAccountsRowChanging;
            
            public event OrgsAccountsRowChangeEventHandler OrgsAccountsRowDeleted;
            
            public event OrgsAccountsRowChangeEventHandler OrgsAccountsRowDeleting;
            
            public void AddOrgsAccountsRow(OrgsAccountsRow row) {
                this.Rows.Add(row);
            }
            
            public OrgsAccountsRow AddOrgsAccountsRow(int AccountID, int OrgID, string RAccount, int BankID, string CurrencyID, string OrgName) {
                OrgsAccountsRow rowOrgsAccountsRow = ((OrgsAccountsRow)(this.NewRow()));
                rowOrgsAccountsRow.ItemArray = new object[] {
                        null,
                        AccountID,
                        OrgID,
                        RAccount,
                        BankID,
                        CurrencyID,
                        OrgName};
                this.Rows.Add(rowOrgsAccountsRow);
                return rowOrgsAccountsRow;
            }
            
            public OrgsAccountsRow FindByOrgsAccountsID(int OrgsAccountsID) {
                return ((OrgsAccountsRow)(this.Rows.Find(new object[] {
                            OrgsAccountsID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                OrgsAccountsDataTable cln = ((OrgsAccountsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new OrgsAccountsDataTable();
            }
            
            internal void InitVars() {
                this.columnOrgsAccountsID = this.Columns["OrgsAccountsID"];
                this.columnAccountID = this.Columns["AccountID"];
                this.columnOrgID = this.Columns["OrgID"];
                this.columnRAccount = this.Columns["RAccount"];
                this.columnBankID = this.Columns["BankID"];
                this.columnCurrencyID = this.Columns["CurrencyID"];
                this.columnOrgName = this.Columns["OrgName"];
            }
            
            private void InitClass() {
                this.columnOrgsAccountsID = new DataColumn("OrgsAccountsID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgsAccountsID);
                this.columnAccountID = new DataColumn("AccountID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAccountID);
                this.columnOrgID = new DataColumn("OrgID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgID);
                this.columnRAccount = new DataColumn("RAccount", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnRAccount);
                this.columnBankID = new DataColumn("BankID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnBankID);
                this.columnCurrencyID = new DataColumn("CurrencyID", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrencyID);
                this.columnOrgName = new DataColumn("OrgName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgName);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnOrgsAccountsID}, true));
                this.columnOrgsAccountsID.AutoIncrement = true;
                this.columnOrgsAccountsID.AllowDBNull = false;
                this.columnOrgsAccountsID.ReadOnly = true;
                this.columnOrgsAccountsID.Unique = true;
                this.columnAccountID.AllowDBNull = false;
                this.columnOrgID.AllowDBNull = false;
                this.columnRAccount.AllowDBNull = false;
            }
            
            public OrgsAccountsRow NewOrgsAccountsRow() {
                return ((OrgsAccountsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new OrgsAccountsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(OrgsAccountsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.OrgsAccountsRowChanged != null)) {
                    this.OrgsAccountsRowChanged(this, new OrgsAccountsRowChangeEvent(((OrgsAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.OrgsAccountsRowChanging != null)) {
                    this.OrgsAccountsRowChanging(this, new OrgsAccountsRowChangeEvent(((OrgsAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.OrgsAccountsRowDeleted != null)) {
                    this.OrgsAccountsRowDeleted(this, new OrgsAccountsRowChangeEvent(((OrgsAccountsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.OrgsAccountsRowDeleting != null)) {
                    this.OrgsAccountsRowDeleting(this, new OrgsAccountsRowChangeEvent(((OrgsAccountsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveOrgsAccountsRow(OrgsAccountsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsAccountsRow : DataRow {
            
            private OrgsAccountsDataTable tableOrgsAccounts;
            
            internal OrgsAccountsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableOrgsAccounts = ((OrgsAccountsDataTable)(this.Table));
            }
            
            public int OrgsAccountsID {
                get {
                    return ((int)(this[this.tableOrgsAccounts.OrgsAccountsIDColumn]));
                }
                set {
                    this[this.tableOrgsAccounts.OrgsAccountsIDColumn] = value;
                }
            }
            
            public int AccountID {
                get {
                    return ((int)(this[this.tableOrgsAccounts.AccountIDColumn]));
                }
                set {
                    this[this.tableOrgsAccounts.AccountIDColumn] = value;
                }
            }
            
            public int OrgID {
                get {
                    return ((int)(this[this.tableOrgsAccounts.OrgIDColumn]));
                }
                set {
                    this[this.tableOrgsAccounts.OrgIDColumn] = value;
                }
            }
            
            public string RAccount {
                get {
                    return ((string)(this[this.tableOrgsAccounts.RAccountColumn]));
                }
                set {
                    this[this.tableOrgsAccounts.RAccountColumn] = value;
                }
            }
            
            public int BankID {
                get {
                    try {
                        return ((int)(this[this.tableOrgsAccounts.BankIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgsAccounts.BankIDColumn] = value;
                }
            }
            
            public string CurrencyID {
                get {
                    try {
                        return ((string)(this[this.tableOrgsAccounts.CurrencyIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgsAccounts.CurrencyIDColumn] = value;
                }
            }
            
            public string OrgName {
                get {
                    try {
                        return ((string)(this[this.tableOrgsAccounts.OrgNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgsAccounts.OrgNameColumn] = value;
                }
            }
            
            public bool IsBankIDNull() {
                return this.IsNull(this.tableOrgsAccounts.BankIDColumn);
            }
            
            public void SetBankIDNull() {
                this[this.tableOrgsAccounts.BankIDColumn] = System.Convert.DBNull;
            }
            
            public bool IsCurrencyIDNull() {
                return this.IsNull(this.tableOrgsAccounts.CurrencyIDColumn);
            }
            
            public void SetCurrencyIDNull() {
                this[this.tableOrgsAccounts.CurrencyIDColumn] = System.Convert.DBNull;
            }
            
            public bool IsOrgNameNull() {
                return this.IsNull(this.tableOrgsAccounts.OrgNameColumn);
            }
            
            public void SetOrgNameNull() {
                this[this.tableOrgsAccounts.OrgNameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsAccountsRowChangeEvent : EventArgs {
            
            private OrgsAccountsRow eventRow;
            
            private DataRowAction eventAction;
            
            public OrgsAccountsRowChangeEvent(OrgsAccountsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public OrgsAccountsRow Row {
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