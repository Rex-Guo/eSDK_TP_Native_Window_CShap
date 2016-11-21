/*Copyright 2015 Huawei Technologies Co., Ltd. All rights reserved.
eSDK is licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
		http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;

namespace TP_Native_Demo.ParameterForms
{
    
    public partial class QueryConfig : Form
    {
        public QueryConfigEx queryConfigEx;
        
        public QueryConfig()
        {
            InitializeComponent();
        }
        
        private void query_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this);

                this.queryConfigEx = new QueryConfigEx();

                //对查询结果按照会场名升序方式进行排序
                List<SortItemsEx> sortItemExs = new List<SortItemsEx>();
                SortItemsEx sortItemEx = new SortItemsEx();
                sortItemEx.sort = Convert.ToInt32(this.tb_Sort.Text.ToString());
                sortItemEx.itemIndex = Convert.ToInt32(this.tb_SortIndex.Text.ToString());
                sortItemExs.Add(sortItemEx);

                //获取满足会场名包含vct2条件的会场
                List<FiltersBaseEx> filtersExs = new List<FiltersBaseEx>();
                StringFilterEx filtersEx = new StringFilterEx();
                filtersEx.columnIndex = Convert.ToInt32(this.tb_columnIndex.Text.ToString());
                filtersEx.value = this.tb_Value.Text.ToString();
                filtersExs.Add(filtersEx);

                //每页5个，获取第一页
                PageParamEx pageParamEx = new PageParamEx();
                pageParamEx.numberPerPage = Convert.ToInt32(this.tb_numberPerPage.Text.ToString());
                pageParamEx.currentPage = Convert.ToInt32(this.tb_currentPage.Text.ToString()); ;

                queryConfigEx.sortItems = sortItemExs.ToArray<SortItemsEx>();
                queryConfigEx.filters = filtersExs.ToArray<FiltersBaseEx>();
                queryConfigEx.focusItem = Convert.ToInt32(this.tb_focusItem.Text.ToString());
                queryConfigEx.pageParam = pageParamEx;

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void tb_Sort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tb_Sort.SelectedItem.ToString().Equals("0：升序"))
            {
                this.tb_Sort.Text="0";
            }
            else if (this.tb_Sort.SelectedItem.ToString().Equals("1：降序"))
            {
                this.tb_Sort.Text = "1";
            }
        }        
       
    }
}
