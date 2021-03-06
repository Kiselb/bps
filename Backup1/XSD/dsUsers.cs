﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.0.3705.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace AuthControl.XSD {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsUsers : DataSet {
        
        private UsersDataTable tableUsers;
        
        public dsUsers() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsUsers(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Users"] != null)) {
                    this.Tables.Add(new UsersDataTable(ds.Tables["Users"]));
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
        public UsersDataTable Users {
            get {
                return this.tableUsers;
            }
        }
        
        public override DataSet Clone() {
            dsUsers cln = ((dsUsers)(base.Clone()));
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
            if ((ds.Tables["Users"] != null)) {
                this.Tables.Add(new UsersDataTable(ds.Tables["Users"]));
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
            this.tableUsers = ((UsersDataTable)(this.Tables["Users"]));
            if ((this.tableUsers != null)) {
                this.tableUsers.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsUsers";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsUsers.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableUsers = new UsersDataTable();
            this.Tables.Add(this.tableUsers);
        }
        
        private bool ShouldSerializeUsers() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void UsersRowChangeEventHandler(object sender, UsersRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class UsersDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnUserID;
            
            private DataColumn columnUserName;
            
            private DataColumn columnUserPassword;
            
            private DataColumn columnGroupID;
            
            private DataColumn columnIsRemoved;
            
            internal UsersDataTable() : 
                    base("Users") {
                this.InitClass();
            }
            
            internal UsersDataTable(DataTable table) : 
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
            
            internal DataColumn UserIDColumn {
                get {
                    return this.columnUserID;
                }
            }
            
            internal DataColumn UserNameColumn {
                get {
                    return this.columnUserName;
                }
            }
            
            internal DataColumn UserPasswordColumn {
                get {
                    return this.columnUserPassword;
                }
            }
            
            internal DataColumn GroupIDColumn {
                get {
                    return this.columnGroupID;
                }
            }
            
            internal DataColumn IsRemovedColumn {
                get {
                    return this.columnIsRemoved;
                }
            }
            
            public UsersRow this[int index] {
                get {
                    return ((UsersRow)(this.Rows[index]));
                }
            }
            
            public event UsersRowChangeEventHandler UsersRowChanged;
            
            public event UsersRowChangeEventHandler UsersRowChanging;
            
            public event UsersRowChangeEventHandler UsersRowDeleted;
            
            public event UsersRowChangeEventHandler UsersRowDeleting;
            
            public void AddUsersRow(UsersRow row) {
                this.Rows.Add(row);
            }
            
            public UsersRow AddUsersRow(string UserName, string UserPassword, int GroupID, bool IsRemoved) {
                UsersRow rowUsersRow = ((UsersRow)(this.NewRow()));
                rowUsersRow.ItemArray = new object[] {
                        null,
                        UserName,
                        UserPassword,
                        GroupID,
                        IsRemoved};
                this.Rows.Add(rowUsersRow);
                return rowUsersRow;
            }
            
            public UsersRow FindByUserID(int UserID) {
                return ((UsersRow)(this.Rows.Find(new object[] {
                            UserID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                UsersDataTable cln = ((UsersDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new UsersDataTable();
            }
            
            internal void InitVars() {
                this.columnUserID = this.Columns["UserID"];
                this.columnUserName = this.Columns["UserName"];
                this.columnUserPassword = this.Columns["UserPassword"];
                this.columnGroupID = this.Columns["GroupID"];
                this.columnIsRemoved = this.Columns["IsRemoved"];
            }
            
            private void InitClass() {
                this.columnUserID = new DataColumn("UserID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserID);
                this.columnUserName = new DataColumn("UserName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserName);
                this.columnUserPassword = new DataColumn("UserPassword", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUserPassword);
                this.columnGroupID = new DataColumn("GroupID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnGroupID);
                this.columnIsRemoved = new DataColumn("IsRemoved", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnIsRemoved);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnUserID}, true));
                this.columnUserID.AutoIncrement = true;
                this.columnUserID.AllowDBNull = false;
                this.columnUserID.Unique = true;
                this.columnUserName.AllowDBNull = false;
                this.columnUserPassword.AllowDBNull = false;
                this.columnGroupID.AllowDBNull = false;
                this.columnIsRemoved.AllowDBNull = false;
            }
            
            public UsersRow NewUsersRow() {
                return ((UsersRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new UsersRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(UsersRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.UsersRowChanged != null)) {
                    this.UsersRowChanged(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.UsersRowChanging != null)) {
                    this.UsersRowChanging(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.UsersRowDeleted != null)) {
                    this.UsersRowDeleted(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.UsersRowDeleting != null)) {
                    this.UsersRowDeleting(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveUsersRow(UsersRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class UsersRow : DataRow {
            
            private UsersDataTable tableUsers;
            
            internal UsersRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableUsers = ((UsersDataTable)(this.Table));
            }
            
            public int UserID {
                get {
                    return ((int)(this[this.tableUsers.UserIDColumn]));
                }
                set {
                    this[this.tableUsers.UserIDColumn] = value;
                }
            }
            
            public string UserName {
                get {
                    return ((string)(this[this.tableUsers.UserNameColumn]));
                }
                set {
                    this[this.tableUsers.UserNameColumn] = value;
                }
            }
            
            public string UserPassword {
                get {
                    return ((string)(this[this.tableUsers.UserPasswordColumn]));
                }
                set {
                    this[this.tableUsers.UserPasswordColumn] = value;
                }
            }
            
            public int GroupID {
                get {
                    return ((int)(this[this.tableUsers.GroupIDColumn]));
                }
                set {
                    this[this.tableUsers.GroupIDColumn] = value;
                }
            }
            
            public bool IsRemoved {
                get {
                    return ((bool)(this[this.tableUsers.IsRemovedColumn]));
                }
                set {
                    this[this.tableUsers.IsRemovedColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class UsersRowChangeEvent : EventArgs {
            
            private UsersRow eventRow;
            
            private DataRowAction eventAction;
            
            public UsersRowChangeEvent(UsersRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public UsersRow Row {
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
