using System;
using System.Data;

namespace CustomReports.Model
{
    /// <summary>
    /// T_YH:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_YH
    {
        public T_YH()
        { }
        #region Model
        private int _f_id;
        private string _f_yhm;
        private string _f_yhmc;
        private string _f_yhbh;
        private int? _f_yhqx;
        private string _f_yhmm;
        private string _f_dlsj;
        private string _f_sfzx;
        private string _f_zxwz;
        private int? _f_zxsc = 0;
        private string _f_dxys;
        private string _f_sfzh = " ";
        private string _f_dhhm = " ";
        private string _f_fjh = " ";
        private string _f_cxts = " ";
        private int _f_dxfpys = 0;
        private string _f_yh_by1 = " ";
        private string _f_yh_by2 = " ";
        /// <summary>
        /// 
        /// </summary>
        public int F_ID
        {
            set { _f_id = value; }
            get { return _f_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YHM
        {
            set { _f_yhm = value; }
            get { return _f_yhm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YHMC
        {
            set { _f_yhmc = value; }
            get { return _f_yhmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YHBH
        {
            set { _f_yhbh = value; }
            get { return _f_yhbh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_YHQX
        {
            set { _f_yhqx = value; }
            get { return _f_yhqx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YHMM
        {
            set { _f_yhmm = value; }
            get { return _f_yhmm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_DLSJ
        {
            set { _f_dlsj = value; }
            get { return _f_dlsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_SFZX
        {
            set { _f_sfzx = value; }
            get { return _f_sfzx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_ZXWZ
        {
            set { _f_zxwz = value; }
            get { return _f_zxwz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? F_ZXSC
        {
            set { _f_zxsc = value; }
            get { return _f_zxsc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_DXYS
        {
            set { _f_dxys = value; }
            get { return _f_dxys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_SFZH
        {
            set { _f_sfzh = value; }
            get { return _f_sfzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_DHHM
        {
            set { _f_dhhm = value; }
            get { return _f_dhhm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_FJH
        {
            set { _f_fjh = value; }
            get { return _f_fjh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_CXTS
        {
            set { _f_cxts = value; }
            get { return _f_cxts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int F_DXFPYS
        {
            set { _f_dxfpys = value; }
            get { return _f_dxfpys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YH_BY1
        {
            set { _f_yh_by1 = value; }
            get { return _f_yh_by1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string F_YH_BY2
        {
            set { _f_yh_by2 = value; }
            get { return _f_yh_by2; }
        }
        #endregion Model

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static T_YH DataRowToModel(DataRow row)
        {
            T_YH model = new T_YH();
            if (row != null)
            {
                if (row["F_ID"] != null && row["F_ID"].ToString() != "")
                {
                    model.F_ID = int.Parse(row["F_ID"].ToString());
                }
                if (row["F_YHM"] != null)
                {
                    model.F_YHM = row["F_YHM"].ToString();
                }
                if (row["F_YHMC"] != null)
                {
                    model.F_YHMC = row["F_YHMC"].ToString();
                }
                if (row["F_YHBH"] != null)
                {
                    model.F_YHBH = row["F_YHBH"].ToString();
                }
                if (row["F_YHQX"] != null && row["F_YHQX"].ToString() != "")
                {
                    model.F_YHQX = int.Parse(row["F_YHQX"].ToString());
                }
                if (row["F_YHMM"] != null)
                {
                    model.F_YHMM = row["F_YHMM"].ToString();
                }
                if (row["F_DLSJ"] != null)
                {
                    model.F_DLSJ = row["F_DLSJ"].ToString();
                }
                if (row["F_SFZX"] != null)
                {
                    model.F_SFZX = row["F_SFZX"].ToString();
                }
                if (row["F_ZXWZ"] != null)
                {
                    model.F_ZXWZ = row["F_ZXWZ"].ToString();
                }
                if (row["F_ZXSC"] != null && row["F_ZXSC"].ToString() != "")
                {
                    model.F_ZXSC = int.Parse(row["F_ZXSC"].ToString());
                }
                if (row["F_DXYS"] != null)
                {
                    model.F_DXYS = row["F_DXYS"].ToString();
                }
                if (row["F_SFZH"] != null)
                {
                    model.F_SFZH = row["F_SFZH"].ToString();
                }
                if (row["F_DHHM"] != null)
                {
                    model.F_DHHM = row["F_DHHM"].ToString();
                }
                if (row["F_FJH"] != null)
                {
                    model.F_FJH = row["F_FJH"].ToString();
                }
                if (row["F_CXTS"] != null)
                {
                    model.F_CXTS = row["F_CXTS"].ToString();
                }
                if (row["F_DXFPYS"] != null && row["F_DXFPYS"].ToString() != "")
                {
                    model.F_DXFPYS = int.Parse(row["F_DXFPYS"].ToString());
                }
                if (row["F_YH_BY1"] != null)
                {
                    model.F_YH_BY1 = row["F_YH_BY1"].ToString();
                }
                if (row["F_YH_BY2"] != null)
                {
                    model.F_YH_BY2 = row["F_YH_BY2"].ToString();
                }
            }
            return model;
        }


    }
}

