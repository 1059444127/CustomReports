using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomReports.Model
{
    public class T_BLK_CS
    {
        public T_BLK_CS()
        {
        }

        #region Model

        private int _f_id;
        private string _f_blkmc;
        private string _f_bggs;
        private string _f_tabid;
        private string _f_bblc_fl;
        private string _f_bsm;
        private string _f_blhmc;
        private int _f_sf = 0;
        private int _f_zps = 0;
        private int _f_tbsid = 0;
        private string _f_tbsmc = " ";
        private string _f_djbgs;
        private string _f_bblx = " ";
        private string _f_blhws = " ";

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
        public string F_BLKMC
        {
            set { _f_blkmc = value; }
            get { return _f_blkmc; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BGGS
        {
            set { _f_bggs = value; }
            get { return _f_bggs; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_TABID
        {
            set { _f_tabid = value; }
            get { return _f_tabid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BBLC_FL
        {
            set { _f_bblc_fl = value; }
            get { return _f_bblc_fl; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BSM
        {
            set { _f_bsm = value; }
            get { return _f_bsm; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BLHMC
        {
            set { _f_blhmc = value; }
            get { return _f_blhmc; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int F_SF
        {
            set { _f_sf = value; }
            get { return _f_sf; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int F_ZPS
        {
            set { _f_zps = value; }
            get { return _f_zps; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int F_TBSID
        {
            set { _f_tbsid = value; }
            get { return _f_tbsid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_TBSMC
        {
            set { _f_tbsmc = value; }
            get { return _f_tbsmc; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_DJBGS
        {
            set { _f_djbgs = value; }
            get { return _f_djbgs; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BBLX
        {
            set { _f_bblx = value; }
            get { return _f_bblx; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string F_BLHWS
        {
            set { _f_blhws = value; }
            get { return _f_blhws; }
        }

        #endregion Model

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static T_BLK_CS DataRowToModel(DataRow row)
        {
            T_BLK_CS model = new T_BLK_CS();
            if (row != null)
            {
                if (row["F_ID"] != null && row["F_ID"].ToString() != "")
                {
                    model.F_ID = int.Parse(row["F_ID"].ToString());
                }
                if (row["F_BLKMC"] != null)
                {
                    model.F_BLKMC = row["F_BLKMC"].ToString();
                }
                if (row["F_BGGS"] != null)
                {
                    model.F_BGGS = row["F_BGGS"].ToString();
                }
                if (row["F_TABID"] != null)
                {
                    model.F_TABID = row["F_TABID"].ToString();
                }
                if (row["F_BBLC_FL"] != null)
                {
                    model.F_BBLC_FL = row["F_BBLC_FL"].ToString();
                }
                if (row["F_BSM"] != null)
                {
                    model.F_BSM = row["F_BSM"].ToString();
                }
                if (row["F_BLHMC"] != null)
                {
                    model.F_BLHMC = row["F_BLHMC"].ToString();
                }
                if (row["F_SF"] != null && row["F_SF"].ToString() != "")
                {
                    model.F_SF = int.Parse(row["F_SF"].ToString());
                }
                if (row["F_ZPS"] != null && row["F_ZPS"].ToString() != "")
                {
                    model.F_ZPS = int.Parse(row["F_ZPS"].ToString());
                }
                if (row["F_TBSID"] != null && row["F_TBSID"].ToString() != "")
                {
                    model.F_TBSID = int.Parse(row["F_TBSID"].ToString());
                }
                if (row["F_TBSMC"] != null)
                {
                    model.F_TBSMC = row["F_TBSMC"].ToString();
                }
                if (row["F_DJBGS"] != null)
                {
                    model.F_DJBGS = row["F_DJBGS"].ToString();
                }
                if (row["F_BBLX"] != null)
                {
                    model.F_BBLX = row["F_BBLX"].ToString();
                }
                if (row["F_BLHWS"] != null)
                {
                    model.F_BLHWS = row["F_BLHWS"].ToString();
                }
            }
            return model;
        }
    }
}