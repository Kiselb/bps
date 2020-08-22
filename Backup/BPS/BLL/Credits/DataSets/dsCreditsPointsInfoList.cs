﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace BPS.BLL.Credits.DataSets {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsCreditsPointsInfoList : DataSet {
        
        private _TableDataTable table_Table;
        
        public dsCreditsPointsInfoList() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsCreditsPointsInfoList(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Table"] != null)) {
                    this.Tables.Add(new _TableDataTable(ds.Tables["Table"]));
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
        public _TableDataTable _Table {
            get {
                return this.table_Table;
            }
        }
        
        public override DataSet Clone() {
            dsCreditsPointsInfoList cln = ((dsCreditsPointsInfoList)(base.Clone()));
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
            if ((ds.Tables["Table"] != null)) {
                this.Tables.Add(new _TableDataTable(ds.Tables["Table"]));
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
            this.table_Table = ((_TableDataTable)(this.Tables["Table"]));
            if ((this.table_Table != null)) {
                this.table_Table.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsCreditsPointsInfoList";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsCreditsPointsInfoList.xsd";
            this.Locale = new System.Globalization.CultureInfo("ru-RU");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.table_Table = new _TableDataTable();
            this.Tables.Add(this.table_Table);
        }
        
        private bool ShouldSerialize_Table() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void _TableRowChangeEventHandler(object sender, _TableRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class _TableDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnPointID;
            
            private DataColumn columnPointDate;
            
            private DataColumn columnPointSum;
            
            private DataColumn columnPointPercent;
            
            private DataColumn columnPointSumSink;
            
            private DataColumn columnPointSumSinkLastDate;
            
            private DataColumn columnPointPercentNormalDebt;
            
            private DataColumn columnPointPercentNormalSink;
            
            private DataColumn columnPointPercentNormalDue;
            
            private DataColumn columnPointPercentNormalDebtLastDate;
            
            private DataColumn columnPointPercentPenaltyDebt;
            
            private DataColumn columnPointPercentPenaltySink;
            
            private DataColumn columnPointPercentPenaltyDue;
            
            private DataColumn columnPointPercentPenaltyDebtLastDate;
            
            private DataColumn columnPointSumIncrease;
            
            private DataColumn columnPointSumIncreaseLastDate;
            
            internal _TableDataTable() : 
                    base("Table") {
                this.InitClass();
            }
            
            internal _TableDataTable(DataTable table) : 
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
            
            internal DataColumn PointIDColumn {
                get {
                    return this.columnPointID;
                }
            }
            
            internal DataColumn PointDateColumn {
                get {
                    return this.columnPointDate;
                }
            }
            
            internal DataColumn PointSumColumn {
                get {
                    return this.columnPointSum;
                }
            }
            
            internal DataColumn PointPercentColumn {
                get {
                    return this.columnPointPercent;
                }
            }
            
            internal DataColumn PointSumSinkColumn {
                get {
                    return this.columnPointSumSink;
                }
            }
            
            internal DataColumn PointSumSinkLastDateColumn {
                get {
                    return this.columnPointSumSinkLastDate;
                }
            }
            
            internal DataColumn PointPercentNormalDebtColumn {
                get {
                    return this.columnPointPercentNormalDebt;
                }
            }
            
            internal DataColumn PointPercentNormalSinkColumn {
                get {
                    return this.columnPointPercentNormalSink;
                }
            }
            
            internal DataColumn PointPercentNormalDueColumn {
                get {
                    return this.columnPointPercentNormalDue;
                }
            }
            
            internal DataColumn PointPercentNormalDebtLastDateColumn {
                get {
                    return this.columnPointPercentNormalDebtLastDate;
                }
            }
            
            internal DataColumn PointPercentPenaltyDebtColumn {
                get {
                    return this.columnPointPercentPenaltyDebt;
                }
            }
            
            internal DataColumn PointPercentPenaltySinkColumn {
                get {
                    return this.columnPointPercentPenaltySink;
                }
            }
            
            internal DataColumn PointPercentPenaltyDueColumn {
                get {
                    return this.columnPointPercentPenaltyDue;
                }
            }
            
            internal DataColumn PointPercentPenaltyDebtLastDateColumn {
                get {
                    return this.columnPointPercentPenaltyDebtLastDate;
                }
            }
            
            internal DataColumn PointSumIncreaseColumn {
                get {
                    return this.columnPointSumIncrease;
                }
            }
            
            internal DataColumn PointSumIncreaseLastDateColumn {
                get {
                    return this.columnPointSumIncreaseLastDate;
                }
            }
            
            public _TableRow this[int index] {
                get {
                    return ((_TableRow)(this.Rows[index]));
                }
            }
            
            public event _TableRowChangeEventHandler _TableRowChanged;
            
            public event _TableRowChangeEventHandler _TableRowChanging;
            
            public event _TableRowChangeEventHandler _TableRowDeleted;
            
            public event _TableRowChangeEventHandler _TableRowDeleting;
            
            public void Add_TableRow(_TableRow row) {
                this.Rows.Add(row);
            }
            
            public _TableRow Add_TableRow(System.DateTime PointDate, System.Double PointSum, System.Double PointPercent, System.Double PointSumSink, System.DateTime PointSumSinkLastDate, System.Double PointPercentNormalDebt, System.Double PointPercentNormalSink, System.Double PointPercentNormalDue, System.DateTime PointPercentNormalDebtLastDate, System.Double PointPercentPenaltyDebt, System.Double PointPercentPenaltySink, System.Double PointPercentPenaltyDue, System.DateTime PointPercentPenaltyDebtLastDate, System.Double PointSumIncrease, System.DateTime PointSumIncreaseLastDate) {
                _TableRow row_TableRow = ((_TableRow)(this.NewRow()));
                row_TableRow.ItemArray = new object[] {
                        null,
                        PointDate,
                        PointSum,
                        PointPercent,
                        PointSumSink,
                        PointSumSinkLastDate,
                        PointPercentNormalDebt,
                        PointPercentNormalSink,
                        PointPercentNormalDue,
                        PointPercentNormalDebtLastDate,
                        PointPercentPenaltyDebt,
                        PointPercentPenaltySink,
                        PointPercentPenaltyDue,
                        PointPercentPenaltyDebtLastDate,
                        PointSumIncrease,
                        PointSumIncreaseLastDate};
                this.Rows.Add(row_TableRow);
                return row_TableRow;
            }
            
            public _TableRow FindByPointID(int PointID) {
                return ((_TableRow)(this.Rows.Find(new object[] {
                            PointID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                _TableDataTable cln = ((_TableDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new _TableDataTable();
            }
            
            internal void InitVars() {
                this.columnPointID = this.Columns["PointID"];
                this.columnPointDate = this.Columns["PointDate"];
                this.columnPointSum = this.Columns["PointSum"];
                this.columnPointPercent = this.Columns["PointPercent"];
                this.columnPointSumSink = this.Columns["PointSumSink"];
                this.columnPointSumSinkLastDate = this.Columns["PointSumSinkLastDate"];
                this.columnPointPercentNormalDebt = this.Columns["PointPercentNormalDebt"];
                this.columnPointPercentNormalSink = this.Columns["PointPercentNormalSink"];
                this.columnPointPercentNormalDue = this.Columns["PointPercentNormalDue"];
                this.columnPointPercentNormalDebtLastDate = this.Columns["PointPercentNormalDebtLastDate"];
                this.columnPointPercentPenaltyDebt = this.Columns["PointPercentPenaltyDebt"];
                this.columnPointPercentPenaltySink = this.Columns["PointPercentPenaltySink"];
                this.columnPointPercentPenaltyDue = this.Columns["PointPercentPenaltyDue"];
                this.columnPointPercentPenaltyDebtLastDate = this.Columns["PointPercentPenaltyDebtLastDate"];
                this.columnPointSumIncrease = this.Columns["PointSumIncrease"];
                this.columnPointSumIncreaseLastDate = this.Columns["PointSumIncreaseLastDate"];
            }
            
            private void InitClass() {
                this.columnPointID = new DataColumn("PointID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointID);
                this.columnPointDate = new DataColumn("PointDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointDate);
                this.columnPointSum = new DataColumn("PointSum", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointSum);
                this.columnPointPercent = new DataColumn("PointPercent", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercent);
                this.columnPointSumSink = new DataColumn("PointSumSink", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointSumSink);
                this.columnPointSumSinkLastDate = new DataColumn("PointSumSinkLastDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointSumSinkLastDate);
                this.columnPointPercentNormalDebt = new DataColumn("PointPercentNormalDebt", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentNormalDebt);
                this.columnPointPercentNormalSink = new DataColumn("PointPercentNormalSink", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentNormalSink);
                this.columnPointPercentNormalDue = new DataColumn("PointPercentNormalDue", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentNormalDue);
                this.columnPointPercentNormalDebtLastDate = new DataColumn("PointPercentNormalDebtLastDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentNormalDebtLastDate);
                this.columnPointPercentPenaltyDebt = new DataColumn("PointPercentPenaltyDebt", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentPenaltyDebt);
                this.columnPointPercentPenaltySink = new DataColumn("PointPercentPenaltySink", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentPenaltySink);
                this.columnPointPercentPenaltyDue = new DataColumn("PointPercentPenaltyDue", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentPenaltyDue);
                this.columnPointPercentPenaltyDebtLastDate = new DataColumn("PointPercentPenaltyDebtLastDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointPercentPenaltyDebtLastDate);
                this.columnPointSumIncrease = new DataColumn("PointSumIncrease", typeof(System.Double), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointSumIncrease);
                this.columnPointSumIncreaseLastDate = new DataColumn("PointSumIncreaseLastDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPointSumIncreaseLastDate);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnPointID}, true));
                this.columnPointID.AutoIncrement = true;
                this.columnPointID.AllowDBNull = false;
                this.columnPointID.ReadOnly = true;
                this.columnPointID.Unique = true;
                this.columnPointDate.AllowDBNull = false;
                this.columnPointSum.AllowDBNull = false;
                this.columnPointPercent.AllowDBNull = false;
                this.columnPointSumIncrease.DefaultValue = 0;
            }
            
            public _TableRow New_TableRow() {
                return ((_TableRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new _TableRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(_TableRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this._TableRowChanged != null)) {
                    this._TableRowChanged(this, new _TableRowChangeEvent(((_TableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this._TableRowChanging != null)) {
                    this._TableRowChanging(this, new _TableRowChangeEvent(((_TableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this._TableRowDeleted != null)) {
                    this._TableRowDeleted(this, new _TableRowChangeEvent(((_TableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this._TableRowDeleting != null)) {
                    this._TableRowDeleting(this, new _TableRowChangeEvent(((_TableRow)(e.Row)), e.Action));
                }
            }
            
            public void Remove_TableRow(_TableRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class _TableRow : DataRow {
            
            private _TableDataTable table_Table;
            
            internal _TableRow(DataRowBuilder rb) : 
                    base(rb) {
                this.table_Table = ((_TableDataTable)(this.Table));
            }
            
            public int PointID {
                get {
                    return ((int)(this[this.table_Table.PointIDColumn]));
                }
                set {
                    this[this.table_Table.PointIDColumn] = value;
                }
            }
            
            public System.DateTime PointDate {
                get {
                    return ((System.DateTime)(this[this.table_Table.PointDateColumn]));
                }
                set {
                    this[this.table_Table.PointDateColumn] = value;
                }
            }
            
            public System.Double PointSum {
                get {
                    return ((System.Double)(this[this.table_Table.PointSumColumn]));
                }
                set {
                    this[this.table_Table.PointSumColumn] = value;
                }
            }
            
            public System.Double PointPercent {
                get {
                    return ((System.Double)(this[this.table_Table.PointPercentColumn]));
                }
                set {
                    this[this.table_Table.PointPercentColumn] = value;
                }
            }
            
            public System.Double PointSumSink {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointSumSinkColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointSumSinkColumn] = value;
                }
            }
            
            public System.DateTime PointSumSinkLastDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.table_Table.PointSumSinkLastDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointSumSinkLastDateColumn] = value;
                }
            }
            
            public System.Double PointPercentNormalDebt {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentNormalDebtColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentNormalDebtColumn] = value;
                }
            }
            
            public System.Double PointPercentNormalSink {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentNormalSinkColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentNormalSinkColumn] = value;
                }
            }
            
            public System.Double PointPercentNormalDue {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentNormalDueColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentNormalDueColumn] = value;
                }
            }
            
            public System.DateTime PointPercentNormalDebtLastDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.table_Table.PointPercentNormalDebtLastDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentNormalDebtLastDateColumn] = value;
                }
            }
            
            public System.Double PointPercentPenaltyDebt {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentPenaltyDebtColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentPenaltyDebtColumn] = value;
                }
            }
            
            public System.Double PointPercentPenaltySink {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentPenaltySinkColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentPenaltySinkColumn] = value;
                }
            }
            
            public System.Double PointPercentPenaltyDue {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointPercentPenaltyDueColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentPenaltyDueColumn] = value;
                }
            }
            
            public System.DateTime PointPercentPenaltyDebtLastDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.table_Table.PointPercentPenaltyDebtLastDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointPercentPenaltyDebtLastDateColumn] = value;
                }
            }
            
            public System.Double PointSumIncrease {
                get {
                    try {
                        return ((System.Double)(this[this.table_Table.PointSumIncreaseColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointSumIncreaseColumn] = value;
                }
            }
            
            public System.DateTime PointSumIncreaseLastDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.table_Table.PointSumIncreaseLastDateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.table_Table.PointSumIncreaseLastDateColumn] = value;
                }
            }
            
            public bool IsPointSumSinkNull() {
                return this.IsNull(this.table_Table.PointSumSinkColumn);
            }
            
            public void SetPointSumSinkNull() {
                this[this.table_Table.PointSumSinkColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointSumSinkLastDateNull() {
                return this.IsNull(this.table_Table.PointSumSinkLastDateColumn);
            }
            
            public void SetPointSumSinkLastDateNull() {
                this[this.table_Table.PointSumSinkLastDateColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentNormalDebtNull() {
                return this.IsNull(this.table_Table.PointPercentNormalDebtColumn);
            }
            
            public void SetPointPercentNormalDebtNull() {
                this[this.table_Table.PointPercentNormalDebtColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentNormalSinkNull() {
                return this.IsNull(this.table_Table.PointPercentNormalSinkColumn);
            }
            
            public void SetPointPercentNormalSinkNull() {
                this[this.table_Table.PointPercentNormalSinkColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentNormalDueNull() {
                return this.IsNull(this.table_Table.PointPercentNormalDueColumn);
            }
            
            public void SetPointPercentNormalDueNull() {
                this[this.table_Table.PointPercentNormalDueColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentNormalDebtLastDateNull() {
                return this.IsNull(this.table_Table.PointPercentNormalDebtLastDateColumn);
            }
            
            public void SetPointPercentNormalDebtLastDateNull() {
                this[this.table_Table.PointPercentNormalDebtLastDateColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentPenaltyDebtNull() {
                return this.IsNull(this.table_Table.PointPercentPenaltyDebtColumn);
            }
            
            public void SetPointPercentPenaltyDebtNull() {
                this[this.table_Table.PointPercentPenaltyDebtColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentPenaltySinkNull() {
                return this.IsNull(this.table_Table.PointPercentPenaltySinkColumn);
            }
            
            public void SetPointPercentPenaltySinkNull() {
                this[this.table_Table.PointPercentPenaltySinkColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentPenaltyDueNull() {
                return this.IsNull(this.table_Table.PointPercentPenaltyDueColumn);
            }
            
            public void SetPointPercentPenaltyDueNull() {
                this[this.table_Table.PointPercentPenaltyDueColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointPercentPenaltyDebtLastDateNull() {
                return this.IsNull(this.table_Table.PointPercentPenaltyDebtLastDateColumn);
            }
            
            public void SetPointPercentPenaltyDebtLastDateNull() {
                this[this.table_Table.PointPercentPenaltyDebtLastDateColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointSumIncreaseNull() {
                return this.IsNull(this.table_Table.PointSumIncreaseColumn);
            }
            
            public void SetPointSumIncreaseNull() {
                this[this.table_Table.PointSumIncreaseColumn] = System.Convert.DBNull;
            }
            
            public bool IsPointSumIncreaseLastDateNull() {
                return this.IsNull(this.table_Table.PointSumIncreaseLastDateColumn);
            }
            
            public void SetPointSumIncreaseLastDateNull() {
                this[this.table_Table.PointSumIncreaseLastDateColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class _TableRowChangeEvent : EventArgs {
            
            private _TableRow eventRow;
            
            private DataRowAction eventAction;
            
            public _TableRowChangeEvent(_TableRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public _TableRow Row {
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