﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.209
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
    public class dsPrevClientRequest : DataSet {
        
        private GetPrevOrgDataTable tableGetPrevOrg;
        
        private GetPrevOrgAccountDataTable tableGetPrevOrgAccount;
        
        public dsPrevClientRequest() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsPrevClientRequest(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GetPrevOrg"] != null)) {
                    this.Tables.Add(new GetPrevOrgDataTable(ds.Tables["GetPrevOrg"]));
                }
                if ((ds.Tables["GetPrevOrgAccount"] != null)) {
                    this.Tables.Add(new GetPrevOrgAccountDataTable(ds.Tables["GetPrevOrgAccount"]));
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
        public GetPrevOrgDataTable GetPrevOrg {
            get {
                return this.tableGetPrevOrg;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public GetPrevOrgAccountDataTable GetPrevOrgAccount {
            get {
                return this.tableGetPrevOrgAccount;
            }
        }
        
        public override DataSet Clone() {
            dsPrevClientRequest cln = ((dsPrevClientRequest)(base.Clone()));
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
            if ((ds.Tables["GetPrevOrg"] != null)) {
                this.Tables.Add(new GetPrevOrgDataTable(ds.Tables["GetPrevOrg"]));
            }
            if ((ds.Tables["GetPrevOrgAccount"] != null)) {
                this.Tables.Add(new GetPrevOrgAccountDataTable(ds.Tables["GetPrevOrgAccount"]));
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
            this.tableGetPrevOrg = ((GetPrevOrgDataTable)(this.Tables["GetPrevOrg"]));
            if ((this.tableGetPrevOrg != null)) {
                this.tableGetPrevOrg.InitVars();
            }
            this.tableGetPrevOrgAccount = ((GetPrevOrgAccountDataTable)(this.Tables["GetPrevOrgAccount"]));
            if ((this.tableGetPrevOrgAccount != null)) {
                this.tableGetPrevOrgAccount.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsPrevClientRequest";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsPrevClientRequest.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGetPrevOrg = new GetPrevOrgDataTable();
            this.Tables.Add(this.tableGetPrevOrg);
            this.tableGetPrevOrgAccount = new GetPrevOrgAccountDataTable();
            this.Tables.Add(this.tableGetPrevOrgAccount);
        }
        
        private bool ShouldSerializeGetPrevOrg() {
            return false;
        }
        
        private bool ShouldSerializeGetPrevOrgAccount() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GetPrevOrgRowChangeEventHandler(object sender, GetPrevOrgRowChangeEvent e);
        
        public delegate void GetPrevOrgAccountRowChangeEventHandler(object sender, GetPrevOrgAccountRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnOrg;
            
            private DataColumn columnINN;
            
            private DataColumn columnRequestTypeID;
            
            private DataColumn columnKPP;
            
            internal GetPrevOrgDataTable() : 
                    base("GetPrevOrg") {
                this.InitClass();
            }
            
            internal GetPrevOrgDataTable(DataTable table) : 
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
            
            internal DataColumn OrgColumn {
                get {
                    return this.columnOrg;
                }
            }
            
            internal DataColumn INNColumn {
                get {
                    return this.columnINN;
                }
            }
            
            internal DataColumn RequestTypeIDColumn {
                get {
                    return this.columnRequestTypeID;
                }
            }
            
            internal DataColumn KPPColumn {
                get {
                    return this.columnKPP;
                }
            }
            
            public GetPrevOrgRow this[int index] {
                get {
                    return ((GetPrevOrgRow)(this.Rows[index]));
                }
            }
            
            public event GetPrevOrgRowChangeEventHandler GetPrevOrgRowChanged;
            
            public event GetPrevOrgRowChangeEventHandler GetPrevOrgRowChanging;
            
            public event GetPrevOrgRowChangeEventHandler GetPrevOrgRowDeleted;
            
            public event GetPrevOrgRowChangeEventHandler GetPrevOrgRowDeleting;
            
            public void AddGetPrevOrgRow(GetPrevOrgRow row) {
                this.Rows.Add(row);
            }
            
            public GetPrevOrgRow AddGetPrevOrgRow(string Org, string INN, int RequestTypeID, string KPP) {
                GetPrevOrgRow rowGetPrevOrgRow = ((GetPrevOrgRow)(this.NewRow()));
                rowGetPrevOrgRow.ItemArray = new object[] {
                        Org,
                        INN,
                        RequestTypeID,
                        KPP};
                this.Rows.Add(rowGetPrevOrgRow);
                return rowGetPrevOrgRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GetPrevOrgDataTable cln = ((GetPrevOrgDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GetPrevOrgDataTable();
            }
            
            internal void InitVars() {
                this.columnOrg = this.Columns["Org"];
                this.columnINN = this.Columns["INN"];
                this.columnRequestTypeID = this.Columns["RequestTypeID"];
                this.columnKPP = this.Columns["KPP"];
            }
            
            private void InitClass() {
                this.columnOrg = new DataColumn("Org", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrg);
                this.columnINN = new DataColumn("INN", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnINN);
                this.columnRequestTypeID = new DataColumn("RequestTypeID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnRequestTypeID);
                this.columnKPP = new DataColumn("KPP", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnKPP);
                this.columnRequestTypeID.AllowDBNull = false;
            }
            
            public GetPrevOrgRow NewGetPrevOrgRow() {
                return ((GetPrevOrgRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GetPrevOrgRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GetPrevOrgRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GetPrevOrgRowChanged != null)) {
                    this.GetPrevOrgRowChanged(this, new GetPrevOrgRowChangeEvent(((GetPrevOrgRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GetPrevOrgRowChanging != null)) {
                    this.GetPrevOrgRowChanging(this, new GetPrevOrgRowChangeEvent(((GetPrevOrgRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GetPrevOrgRowDeleted != null)) {
                    this.GetPrevOrgRowDeleted(this, new GetPrevOrgRowChangeEvent(((GetPrevOrgRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GetPrevOrgRowDeleting != null)) {
                    this.GetPrevOrgRowDeleting(this, new GetPrevOrgRowChangeEvent(((GetPrevOrgRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGetPrevOrgRow(GetPrevOrgRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgRow : DataRow {
            
            private GetPrevOrgDataTable tableGetPrevOrg;
            
            internal GetPrevOrgRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGetPrevOrg = ((GetPrevOrgDataTable)(this.Table));
            }
            
            public string Org {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrg.OrgColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrg.OrgColumn] = value;
                }
            }
            
            public string INN {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrg.INNColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrg.INNColumn] = value;
                }
            }
            
            public int RequestTypeID {
                get {
                    return ((int)(this[this.tableGetPrevOrg.RequestTypeIDColumn]));
                }
                set {
                    this[this.tableGetPrevOrg.RequestTypeIDColumn] = value;
                }
            }
            
            public string KPP {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrg.KPPColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrg.KPPColumn] = value;
                }
            }
            
            public bool IsOrgNull() {
                return this.IsNull(this.tableGetPrevOrg.OrgColumn);
            }
            
            public void SetOrgNull() {
                this[this.tableGetPrevOrg.OrgColumn] = System.Convert.DBNull;
            }
            
            public bool IsINNNull() {
                return this.IsNull(this.tableGetPrevOrg.INNColumn);
            }
            
            public void SetINNNull() {
                this[this.tableGetPrevOrg.INNColumn] = System.Convert.DBNull;
            }
            
            public bool IsKPPNull() {
                return this.IsNull(this.tableGetPrevOrg.KPPColumn);
            }
            
            public void SetKPPNull() {
                this[this.tableGetPrevOrg.KPPColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgRowChangeEvent : EventArgs {
            
            private GetPrevOrgRow eventRow;
            
            private DataRowAction eventAction;
            
            public GetPrevOrgRowChangeEvent(GetPrevOrgRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GetPrevOrgRow Row {
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
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgAccountDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnOrg;
            
            private DataColumn columnINN;
            
            private DataColumn columnRequestTypeID;
            
            private DataColumn columnAccount;
            
            private DataColumn columnBankName;
            
            private DataColumn columnCodeBIK;
            
            private DataColumn columnPurpose;
            
            private DataColumn columnOrgIn;
            
            private DataColumn columnKPP;
            
            internal GetPrevOrgAccountDataTable() : 
                    base("GetPrevOrgAccount") {
                this.InitClass();
            }
            
            internal GetPrevOrgAccountDataTable(DataTable table) : 
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
            
            internal DataColumn OrgColumn {
                get {
                    return this.columnOrg;
                }
            }
            
            internal DataColumn INNColumn {
                get {
                    return this.columnINN;
                }
            }
            
            internal DataColumn RequestTypeIDColumn {
                get {
                    return this.columnRequestTypeID;
                }
            }
            
            internal DataColumn AccountColumn {
                get {
                    return this.columnAccount;
                }
            }
            
            internal DataColumn BankNameColumn {
                get {
                    return this.columnBankName;
                }
            }
            
            internal DataColumn CodeBIKColumn {
                get {
                    return this.columnCodeBIK;
                }
            }
            
            internal DataColumn PurposeColumn {
                get {
                    return this.columnPurpose;
                }
            }
            
            internal DataColumn OrgInColumn {
                get {
                    return this.columnOrgIn;
                }
            }
            
            internal DataColumn KPPColumn {
                get {
                    return this.columnKPP;
                }
            }
            
            public GetPrevOrgAccountRow this[int index] {
                get {
                    return ((GetPrevOrgAccountRow)(this.Rows[index]));
                }
            }
            
            public event GetPrevOrgAccountRowChangeEventHandler GetPrevOrgAccountRowChanged;
            
            public event GetPrevOrgAccountRowChangeEventHandler GetPrevOrgAccountRowChanging;
            
            public event GetPrevOrgAccountRowChangeEventHandler GetPrevOrgAccountRowDeleted;
            
            public event GetPrevOrgAccountRowChangeEventHandler GetPrevOrgAccountRowDeleting;
            
            public void AddGetPrevOrgAccountRow(GetPrevOrgAccountRow row) {
                this.Rows.Add(row);
            }
            
            public GetPrevOrgAccountRow AddGetPrevOrgAccountRow(string Org, string INN, int RequestTypeID, string Account, string BankName, string CodeBIK, string Purpose, string OrgIn, string KPP) {
                GetPrevOrgAccountRow rowGetPrevOrgAccountRow = ((GetPrevOrgAccountRow)(this.NewRow()));
                rowGetPrevOrgAccountRow.ItemArray = new object[] {
                        Org,
                        INN,
                        RequestTypeID,
                        Account,
                        BankName,
                        CodeBIK,
                        Purpose,
                        OrgIn,
                        KPP};
                this.Rows.Add(rowGetPrevOrgAccountRow);
                return rowGetPrevOrgAccountRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GetPrevOrgAccountDataTable cln = ((GetPrevOrgAccountDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GetPrevOrgAccountDataTable();
            }
            
            internal void InitVars() {
                this.columnOrg = this.Columns["Org"];
                this.columnINN = this.Columns["INN"];
                this.columnRequestTypeID = this.Columns["RequestTypeID"];
                this.columnAccount = this.Columns["Account"];
                this.columnBankName = this.Columns["BankName"];
                this.columnCodeBIK = this.Columns["CodeBIK"];
                this.columnPurpose = this.Columns["Purpose"];
                this.columnOrgIn = this.Columns["OrgIn"];
                this.columnKPP = this.Columns["KPP"];
            }
            
            private void InitClass() {
                this.columnOrg = new DataColumn("Org", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrg);
                this.columnINN = new DataColumn("INN", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnINN);
                this.columnRequestTypeID = new DataColumn("RequestTypeID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnRequestTypeID);
                this.columnAccount = new DataColumn("Account", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAccount);
                this.columnBankName = new DataColumn("BankName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnBankName);
                this.columnCodeBIK = new DataColumn("CodeBIK", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCodeBIK);
                this.columnPurpose = new DataColumn("Purpose", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPurpose);
                this.columnOrgIn = new DataColumn("OrgIn", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgIn);
                this.columnKPP = new DataColumn("KPP", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnKPP);
                this.columnRequestTypeID.AllowDBNull = false;
                this.columnOrgIn.ReadOnly = true;
            }
            
            public GetPrevOrgAccountRow NewGetPrevOrgAccountRow() {
                return ((GetPrevOrgAccountRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GetPrevOrgAccountRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GetPrevOrgAccountRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GetPrevOrgAccountRowChanged != null)) {
                    this.GetPrevOrgAccountRowChanged(this, new GetPrevOrgAccountRowChangeEvent(((GetPrevOrgAccountRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GetPrevOrgAccountRowChanging != null)) {
                    this.GetPrevOrgAccountRowChanging(this, new GetPrevOrgAccountRowChangeEvent(((GetPrevOrgAccountRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GetPrevOrgAccountRowDeleted != null)) {
                    this.GetPrevOrgAccountRowDeleted(this, new GetPrevOrgAccountRowChangeEvent(((GetPrevOrgAccountRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GetPrevOrgAccountRowDeleting != null)) {
                    this.GetPrevOrgAccountRowDeleting(this, new GetPrevOrgAccountRowChangeEvent(((GetPrevOrgAccountRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGetPrevOrgAccountRow(GetPrevOrgAccountRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgAccountRow : DataRow {
            
            private GetPrevOrgAccountDataTable tableGetPrevOrgAccount;
            
            internal GetPrevOrgAccountRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGetPrevOrgAccount = ((GetPrevOrgAccountDataTable)(this.Table));
            }
            
            public string Org {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.OrgColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.OrgColumn] = value;
                }
            }
            
            public string INN {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.INNColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.INNColumn] = value;
                }
            }
            
            public int RequestTypeID {
                get {
                    return ((int)(this[this.tableGetPrevOrgAccount.RequestTypeIDColumn]));
                }
                set {
                    this[this.tableGetPrevOrgAccount.RequestTypeIDColumn] = value;
                }
            }
            
            public string Account {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.AccountColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.AccountColumn] = value;
                }
            }
            
            public string BankName {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.BankNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.BankNameColumn] = value;
                }
            }
            
            public string CodeBIK {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.CodeBIKColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.CodeBIKColumn] = value;
                }
            }
            
            public string Purpose {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.PurposeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.PurposeColumn] = value;
                }
            }
            
            public string OrgIn {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.OrgInColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.OrgInColumn] = value;
                }
            }
            
            public string KPP {
                get {
                    try {
                        return ((string)(this[this.tableGetPrevOrgAccount.KPPColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGetPrevOrgAccount.KPPColumn] = value;
                }
            }
            
            public bool IsOrgNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.OrgColumn);
            }
            
            public void SetOrgNull() {
                this[this.tableGetPrevOrgAccount.OrgColumn] = System.Convert.DBNull;
            }
            
            public bool IsINNNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.INNColumn);
            }
            
            public void SetINNNull() {
                this[this.tableGetPrevOrgAccount.INNColumn] = System.Convert.DBNull;
            }
            
            public bool IsAccountNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.AccountColumn);
            }
            
            public void SetAccountNull() {
                this[this.tableGetPrevOrgAccount.AccountColumn] = System.Convert.DBNull;
            }
            
            public bool IsBankNameNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.BankNameColumn);
            }
            
            public void SetBankNameNull() {
                this[this.tableGetPrevOrgAccount.BankNameColumn] = System.Convert.DBNull;
            }
            
            public bool IsCodeBIKNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.CodeBIKColumn);
            }
            
            public void SetCodeBIKNull() {
                this[this.tableGetPrevOrgAccount.CodeBIKColumn] = System.Convert.DBNull;
            }
            
            public bool IsPurposeNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.PurposeColumn);
            }
            
            public void SetPurposeNull() {
                this[this.tableGetPrevOrgAccount.PurposeColumn] = System.Convert.DBNull;
            }
            
            public bool IsOrgInNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.OrgInColumn);
            }
            
            public void SetOrgInNull() {
                this[this.tableGetPrevOrgAccount.OrgInColumn] = System.Convert.DBNull;
            }
            
            public bool IsKPPNull() {
                return this.IsNull(this.tableGetPrevOrgAccount.KPPColumn);
            }
            
            public void SetKPPNull() {
                this[this.tableGetPrevOrgAccount.KPPColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GetPrevOrgAccountRowChangeEvent : EventArgs {
            
            private GetPrevOrgAccountRow eventRow;
            
            private DataRowAction eventAction;
            
            public GetPrevOrgAccountRowChangeEvent(GetPrevOrgAccountRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GetPrevOrgAccountRow Row {
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
