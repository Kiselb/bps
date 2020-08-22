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
    public class dsOrgs : DataSet {
        
        private OrgsDataTable tableOrgs;
        
        public dsOrgs() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsOrgs(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Orgs"] != null)) {
                    this.Tables.Add(new OrgsDataTable(ds.Tables["Orgs"]));
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
        public OrgsDataTable Orgs {
            get {
                return this.tableOrgs;
            }
        }
        
        public override DataSet Clone() {
            dsOrgs cln = ((dsOrgs)(base.Clone()));
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
            if ((ds.Tables["Orgs"] != null)) {
                this.Tables.Add(new OrgsDataTable(ds.Tables["Orgs"]));
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
            this.tableOrgs = ((OrgsDataTable)(this.Tables["Orgs"]));
            if ((this.tableOrgs != null)) {
                this.tableOrgs.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsOrgs";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsOrgs.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableOrgs = new OrgsDataTable();
            this.Tables.Add(this.tableOrgs);
        }
        
        private bool ShouldSerializeOrgs() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void OrgsRowChangeEventHandler(object sender, OrgsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnOrgID;
            
            private DataColumn columnOrgName;
            
            private DataColumn columnOrgName2;
            
            private DataColumn columnIsNormal;
            
            private DataColumn columnIsInner;
            
            private DataColumn columnIsSpecial;
            
            private DataColumn columnDefaultServiceCharge;
            
            private DataColumn columnCodeINN;
            
            private DataColumn columnCodeKPP;
            
            private DataColumn columnAddrReg;
            
            private DataColumn columnAddrFact;
            
            private DataColumn columnPhone1;
            
            private DataColumn columnPhone2;
            
            private DataColumn columnFax1;
            
            private DataColumn columnFax2;
            
            private DataColumn columnContactPerson;
            
            private DataColumn columnOKPO;
            
            private DataColumn columnOKONH;
            
            private DataColumn columnClientID;
            
            private DataColumn columnIsRemoved;
            
            private DataColumn columnClientName;
            
            internal OrgsDataTable() : 
                    base("Orgs") {
                this.InitClass();
            }
            
            internal OrgsDataTable(DataTable table) : 
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
            
            internal DataColumn OrgIDColumn {
                get {
                    return this.columnOrgID;
                }
            }
            
            internal DataColumn OrgNameColumn {
                get {
                    return this.columnOrgName;
                }
            }
            
            internal DataColumn OrgName2Column {
                get {
                    return this.columnOrgName2;
                }
            }
            
            internal DataColumn IsNormalColumn {
                get {
                    return this.columnIsNormal;
                }
            }
            
            internal DataColumn IsInnerColumn {
                get {
                    return this.columnIsInner;
                }
            }
            
            internal DataColumn IsSpecialColumn {
                get {
                    return this.columnIsSpecial;
                }
            }
            
            internal DataColumn DefaultServiceChargeColumn {
                get {
                    return this.columnDefaultServiceCharge;
                }
            }
            
            internal DataColumn CodeINNColumn {
                get {
                    return this.columnCodeINN;
                }
            }
            
            internal DataColumn CodeKPPColumn {
                get {
                    return this.columnCodeKPP;
                }
            }
            
            internal DataColumn AddrRegColumn {
                get {
                    return this.columnAddrReg;
                }
            }
            
            internal DataColumn AddrFactColumn {
                get {
                    return this.columnAddrFact;
                }
            }
            
            internal DataColumn Phone1Column {
                get {
                    return this.columnPhone1;
                }
            }
            
            internal DataColumn Phone2Column {
                get {
                    return this.columnPhone2;
                }
            }
            
            internal DataColumn Fax1Column {
                get {
                    return this.columnFax1;
                }
            }
            
            internal DataColumn Fax2Column {
                get {
                    return this.columnFax2;
                }
            }
            
            internal DataColumn ContactPersonColumn {
                get {
                    return this.columnContactPerson;
                }
            }
            
            internal DataColumn OKPOColumn {
                get {
                    return this.columnOKPO;
                }
            }
            
            internal DataColumn OKONHColumn {
                get {
                    return this.columnOKONH;
                }
            }
            
            internal DataColumn ClientIDColumn {
                get {
                    return this.columnClientID;
                }
            }
            
            internal DataColumn IsRemovedColumn {
                get {
                    return this.columnIsRemoved;
                }
            }
            
            internal DataColumn ClientNameColumn {
                get {
                    return this.columnClientName;
                }
            }
            
            public OrgsRow this[int index] {
                get {
                    return ((OrgsRow)(this.Rows[index]));
                }
            }
            
            public event OrgsRowChangeEventHandler OrgsRowChanged;
            
            public event OrgsRowChangeEventHandler OrgsRowChanging;
            
            public event OrgsRowChangeEventHandler OrgsRowDeleted;
            
            public event OrgsRowChangeEventHandler OrgsRowDeleting;
            
            public void AddOrgsRow(OrgsRow row) {
                this.Rows.Add(row);
            }
            
            public OrgsRow AddOrgsRow(
                        string OrgName, 
                        string OrgName2, 
                        bool IsNormal, 
                        bool IsInner, 
                        bool IsSpecial, 
                        System.Double DefaultServiceCharge, 
                        string CodeINN, 
                        string CodeKPP, 
                        string AddrReg, 
                        string AddrFact, 
                        string Phone1, 
                        string Phone2, 
                        string Fax1, 
                        string Fax2, 
                        string ContactPerson, 
                        string OKPO, 
                        string OKONH, 
                        int ClientID, 
                        bool IsRemoved, 
                        string ClientName) {
                OrgsRow rowOrgsRow = ((OrgsRow)(this.NewRow()));
                rowOrgsRow.ItemArray = new object[] {
                        null,
                        OrgName,
                        OrgName2,
                        IsNormal,
                        IsInner,
                        IsSpecial,
                        DefaultServiceCharge,
                        CodeINN,
                        CodeKPP,
                        AddrReg,
                        AddrFact,
                        Phone1,
                        Phone2,
                        Fax1,
                        Fax2,
                        ContactPerson,
                        OKPO,
                        OKONH,
                        ClientID,
                        IsRemoved,
                        ClientName};
                this.Rows.Add(rowOrgsRow);
                return rowOrgsRow;
            }
            
            public OrgsRow FindByOrgID(int OrgID) {
                return ((OrgsRow)(this.Rows.Find(new object[] {
                            OrgID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                OrgsDataTable cln = ((OrgsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new OrgsDataTable();
            }
            
            internal void InitVars() {
                this.columnOrgID = this.Columns["OrgID"];
                this.columnOrgName = this.Columns["OrgName"];
                this.columnOrgName2 = this.Columns["OrgName2"];
                this.columnIsNormal = this.Columns["IsNormal"];
                this.columnIsInner = this.Columns["IsInner"];
                this.columnIsSpecial = this.Columns["IsSpecial"];
                this.columnDefaultServiceCharge = this.Columns["DefaultServiceCharge"];
                this.columnCodeINN = this.Columns["CodeINN"];
                this.columnCodeKPP = this.Columns["CodeKPP"];
                this.columnAddrReg = this.Columns["AddrReg"];
                this.columnAddrFact = this.Columns["AddrFact"];
                this.columnPhone1 = this.Columns["Phone1"];
                this.columnPhone2 = this.Columns["Phone2"];
                this.columnFax1 = this.Columns["Fax1"];
                this.columnFax2 = this.Columns["Fax2"];
                this.columnContactPerson = this.Columns["ContactPerson"];
                this.columnOKPO = this.Columns["OKPO"];
                this.columnOKONH = this.Columns["OKONH"];
                this.columnClientID = this.Columns["ClientID"];
                this.columnIsRemoved = this.Columns["IsRemoved"];
                this.columnClientName = this.Columns["ClientName"];
            }
            
            private void InitClass() {
                this.columnOrgID = new DataColumn("OrgID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgID);
                this.columnOrgName = new DataColumn("OrgName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgName);
                this.columnOrgName2 = new DataColumn("OrgName2", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOrgName2);
                this.columnIsNormal = new DataColumn("IsNormal", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsNormal);
                this.columnIsInner = new DataColumn("IsInner", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsInner);
                this.columnIsSpecial = new DataColumn("IsSpecial", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsSpecial);
                this.columnDefaultServiceCharge = new DataColumn("DefaultServiceCharge", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnDefaultServiceCharge);
                this.columnCodeINN = new DataColumn("CodeINN", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCodeINN);
                this.columnCodeKPP = new DataColumn("CodeKPP", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCodeKPP);
                this.columnAddrReg = new DataColumn("AddrReg", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAddrReg);
                this.columnAddrFact = new DataColumn("AddrFact", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAddrFact);
                this.columnPhone1 = new DataColumn("Phone1", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhone1);
                this.columnPhone2 = new DataColumn("Phone2", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhone2);
                this.columnFax1 = new DataColumn("Fax1", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFax1);
                this.columnFax2 = new DataColumn("Fax2", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFax2);
                this.columnContactPerson = new DataColumn("ContactPerson", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnContactPerson);
                this.columnOKPO = new DataColumn("OKPO", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOKPO);
                this.columnOKONH = new DataColumn("OKONH", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOKONH);
                this.columnClientID = new DataColumn("ClientID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnClientID);
                this.columnIsRemoved = new DataColumn("IsRemoved", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsRemoved);
                this.columnClientName = new DataColumn("ClientName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnClientName);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnOrgID}, true));
                this.columnOrgID.AutoIncrement = true;
                this.columnOrgID.AllowDBNull = false;
                this.columnOrgID.ReadOnly = true;
                this.columnOrgID.Unique = true;
                this.columnOrgName.AllowDBNull = false;
                this.columnIsNormal.AllowDBNull = false;
                this.columnIsInner.AllowDBNull = false;
                this.columnIsSpecial.AllowDBNull = false;
                this.columnCodeINN.AllowDBNull = false;
                this.columnIsRemoved.DefaultValue = false;
            }
            
            public OrgsRow NewOrgsRow() {
                return ((OrgsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new OrgsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(OrgsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.OrgsRowChanged != null)) {
                    this.OrgsRowChanged(this, new OrgsRowChangeEvent(((OrgsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.OrgsRowChanging != null)) {
                    this.OrgsRowChanging(this, new OrgsRowChangeEvent(((OrgsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.OrgsRowDeleted != null)) {
                    this.OrgsRowDeleted(this, new OrgsRowChangeEvent(((OrgsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.OrgsRowDeleting != null)) {
                    this.OrgsRowDeleting(this, new OrgsRowChangeEvent(((OrgsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveOrgsRow(OrgsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsRow : DataRow {
            
            private OrgsDataTable tableOrgs;
            
            internal OrgsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableOrgs = ((OrgsDataTable)(this.Table));
            }
            
            public int OrgID {
                get {
                    return ((int)(this[this.tableOrgs.OrgIDColumn]));
                }
                set {
                    this[this.tableOrgs.OrgIDColumn] = value;
                }
            }
            
            public string OrgName {
                get {
                    return ((string)(this[this.tableOrgs.OrgNameColumn]));
                }
                set {
                    this[this.tableOrgs.OrgNameColumn] = value;
                }
            }
            
            public string OrgName2 {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.OrgName2Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.OrgName2Column] = value;
                }
            }
            
            public bool IsNormal {
                get {
                    return ((bool)(this[this.tableOrgs.IsNormalColumn]));
                }
                set {
                    this[this.tableOrgs.IsNormalColumn] = value;
                }
            }
            
            public bool IsInner {
                get {
                    return ((bool)(this[this.tableOrgs.IsInnerColumn]));
                }
                set {
                    this[this.tableOrgs.IsInnerColumn] = value;
                }
            }
            
            public bool IsSpecial {
                get {
                    return ((bool)(this[this.tableOrgs.IsSpecialColumn]));
                }
                set {
                    this[this.tableOrgs.IsSpecialColumn] = value;
                }
            }
            
            public System.Double DefaultServiceCharge {
                get {
                    try {
                        return ((System.Double)(this[this.tableOrgs.DefaultServiceChargeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.DefaultServiceChargeColumn] = value;
                }
            }
            
            public string CodeINN {
                get {
                    return ((string)(this[this.tableOrgs.CodeINNColumn]));
                }
                set {
                    this[this.tableOrgs.CodeINNColumn] = value;
                }
            }
            
            public string CodeKPP {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.CodeKPPColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.CodeKPPColumn] = value;
                }
            }
            
            public string AddrReg {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.AddrRegColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.AddrRegColumn] = value;
                }
            }
            
            public string AddrFact {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.AddrFactColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.AddrFactColumn] = value;
                }
            }
            
            public string Phone1 {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.Phone1Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.Phone1Column] = value;
                }
            }
            
            public string Phone2 {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.Phone2Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.Phone2Column] = value;
                }
            }
            
            public string Fax1 {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.Fax1Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.Fax1Column] = value;
                }
            }
            
            public string Fax2 {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.Fax2Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.Fax2Column] = value;
                }
            }
            
            public string ContactPerson {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.ContactPersonColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.ContactPersonColumn] = value;
                }
            }
            
            public string OKPO {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.OKPOColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.OKPOColumn] = value;
                }
            }
            
            public string OKONH {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.OKONHColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.OKONHColumn] = value;
                }
            }
            
            public int ClientID {
                get {
                    try {
                        return ((int)(this[this.tableOrgs.ClientIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.ClientIDColumn] = value;
                }
            }
            
            public bool IsRemoved {
                get {
                    try {
                        return ((bool)(this[this.tableOrgs.IsRemovedColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.IsRemovedColumn] = value;
                }
            }
            
            public string ClientName {
                get {
                    try {
                        return ((string)(this[this.tableOrgs.ClientNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableOrgs.ClientNameColumn] = value;
                }
            }
            
            public bool IsOrgName2Null() {
                return this.IsNull(this.tableOrgs.OrgName2Column);
            }
            
            public void SetOrgName2Null() {
                this[this.tableOrgs.OrgName2Column] = System.Convert.DBNull;
            }
            
            public bool IsDefaultServiceChargeNull() {
                return this.IsNull(this.tableOrgs.DefaultServiceChargeColumn);
            }
            
            public void SetDefaultServiceChargeNull() {
                this[this.tableOrgs.DefaultServiceChargeColumn] = System.Convert.DBNull;
            }
            
            public bool IsCodeKPPNull() {
                return this.IsNull(this.tableOrgs.CodeKPPColumn);
            }
            
            public void SetCodeKPPNull() {
                this[this.tableOrgs.CodeKPPColumn] = System.Convert.DBNull;
            }
            
            public bool IsAddrRegNull() {
                return this.IsNull(this.tableOrgs.AddrRegColumn);
            }
            
            public void SetAddrRegNull() {
                this[this.tableOrgs.AddrRegColumn] = System.Convert.DBNull;
            }
            
            public bool IsAddrFactNull() {
                return this.IsNull(this.tableOrgs.AddrFactColumn);
            }
            
            public void SetAddrFactNull() {
                this[this.tableOrgs.AddrFactColumn] = System.Convert.DBNull;
            }
            
            public bool IsPhone1Null() {
                return this.IsNull(this.tableOrgs.Phone1Column);
            }
            
            public void SetPhone1Null() {
                this[this.tableOrgs.Phone1Column] = System.Convert.DBNull;
            }
            
            public bool IsPhone2Null() {
                return this.IsNull(this.tableOrgs.Phone2Column);
            }
            
            public void SetPhone2Null() {
                this[this.tableOrgs.Phone2Column] = System.Convert.DBNull;
            }
            
            public bool IsFax1Null() {
                return this.IsNull(this.tableOrgs.Fax1Column);
            }
            
            public void SetFax1Null() {
                this[this.tableOrgs.Fax1Column] = System.Convert.DBNull;
            }
            
            public bool IsFax2Null() {
                return this.IsNull(this.tableOrgs.Fax2Column);
            }
            
            public void SetFax2Null() {
                this[this.tableOrgs.Fax2Column] = System.Convert.DBNull;
            }
            
            public bool IsContactPersonNull() {
                return this.IsNull(this.tableOrgs.ContactPersonColumn);
            }
            
            public void SetContactPersonNull() {
                this[this.tableOrgs.ContactPersonColumn] = System.Convert.DBNull;
            }
            
            public bool IsOKPONull() {
                return this.IsNull(this.tableOrgs.OKPOColumn);
            }
            
            public void SetOKPONull() {
                this[this.tableOrgs.OKPOColumn] = System.Convert.DBNull;
            }
            
            public bool IsOKONHNull() {
                return this.IsNull(this.tableOrgs.OKONHColumn);
            }
            
            public void SetOKONHNull() {
                this[this.tableOrgs.OKONHColumn] = System.Convert.DBNull;
            }
            
            public bool IsClientIDNull() {
                return this.IsNull(this.tableOrgs.ClientIDColumn);
            }
            
            public void SetClientIDNull() {
                this[this.tableOrgs.ClientIDColumn] = System.Convert.DBNull;
            }
            
            public bool IsIsRemovedNull() {
                return this.IsNull(this.tableOrgs.IsRemovedColumn);
            }
            
            public void SetIsRemovedNull() {
                this[this.tableOrgs.IsRemovedColumn] = System.Convert.DBNull;
            }
            
            public bool IsClientNameNull() {
                return this.IsNull(this.tableOrgs.ClientNameColumn);
            }
            
            public void SetClientNameNull() {
                this[this.tableOrgs.ClientNameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class OrgsRowChangeEvent : EventArgs {
            
            private OrgsRow eventRow;
            
            private DataRowAction eventAction;
            
            public OrgsRowChangeEvent(OrgsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public OrgsRow Row {
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
