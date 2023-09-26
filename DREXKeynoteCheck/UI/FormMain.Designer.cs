namespace DREXKeynoteCheck.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvElement = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLoadPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.clnカテゴリ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnファミリ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnタイプ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnキーノート = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnキーノート名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cln配置数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnサイズ確認結果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvElement
            // 
            this.dgvElement.AllowUserToAddRows = false;
            this.dgvElement.AllowUserToDeleteRows = false;
            this.dgvElement.AllowUserToResizeRows = false;
            this.dgvElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnカテゴリ,
            this.clnファミリ,
            this.clnタイプ,
            this.clnキーノート,
            this.clnキーノート名称,
            this.cln配置数,
            this.clnサイズ確認結果});
            this.dgvElement.Location = new System.Drawing.Point(9, 70);
            this.dgvElement.Margin = new System.Windows.Forms.Padding(2);
            this.dgvElement.Name = "dgvElement";
            this.dgvElement.RowHeadersVisible = false;
            this.dgvElement.RowHeadersWidth = 51;
            this.dgvElement.RowTemplate.Height = 24;
            this.dgvElement.Size = new System.Drawing.Size(1249, 390);
            this.dgvElement.TabIndex = 0;
            this.dgvElement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElement_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(1178, 466);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "タイプに対するパラメータのチェック";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "参照ファイル";
            // 
            // textLoadPath
            // 
            this.textLoadPath.Location = new System.Drawing.Point(83, 38);
            this.textLoadPath.Name = "textLoadPath";
            this.textLoadPath.ReadOnly = true;
            this.textLoadPath.Size = new System.Drawing.Size(410, 20);
            this.textLoadPath.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(499, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "読込";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // clnカテゴリ
            // 
            this.clnカテゴリ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnカテゴリ.FillWeight = 40F;
            this.clnカテゴリ.HeaderText = "カテゴリ";
            this.clnカテゴリ.MinimumWidth = 6;
            this.clnカテゴリ.Name = "clnカテゴリ";
            this.clnカテゴリ.ReadOnly = true;
            // 
            // clnファミリ
            // 
            this.clnファミリ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnファミリ.HeaderText = "ファミリ";
            this.clnファミリ.MinimumWidth = 6;
            this.clnファミリ.Name = "clnファミリ";
            this.clnファミリ.ReadOnly = true;
            // 
            // clnタイプ
            // 
            this.clnタイプ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnタイプ.FillWeight = 50F;
            this.clnタイプ.HeaderText = "タイプ";
            this.clnタイプ.MinimumWidth = 6;
            this.clnタイプ.Name = "clnタイプ";
            this.clnタイプ.ReadOnly = true;
            // 
            // clnキーノート
            // 
            this.clnキーノート.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnキーノート.FillWeight = 40F;
            this.clnキーノート.HeaderText = "キーノート";
            this.clnキーノート.MinimumWidth = 6;
            this.clnキーノート.Name = "clnキーノート";
            this.clnキーノート.ReadOnly = true;
            // 
            // clnキーノート名称
            // 
            this.clnキーノート名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnキーノート名称.FillWeight = 130F;
            this.clnキーノート名称.HeaderText = "キーノート名称";
            this.clnキーノート名称.MinimumWidth = 6;
            this.clnキーノート名称.Name = "clnキーノート名称";
            this.clnキーノート名称.ReadOnly = true;
            // 
            // cln配置数
            // 
            this.cln配置数.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cln配置数.FillWeight = 40F;
            this.cln配置数.HeaderText = "配置数";
            this.cln配置数.MinimumWidth = 6;
            this.cln配置数.Name = "cln配置数";
            this.cln配置数.ReadOnly = true;
            // 
            // clnサイズ確認結果
            // 
            this.clnサイズ確認結果.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnサイズ確認結果.FillWeight = 200F;
            this.clnサイズ確認結果.HeaderText = "サイズ確認結果";
            this.clnサイズ確認結果.MinimumWidth = 6;
            this.clnサイズ確認結果.Name = "clnサイズ確認結果";
            this.clnサイズ確認結果.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 497);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textLoadPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvElement);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(1017, 437);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "外構マテリアルキーノートチェック機能";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvElement;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLoadPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnカテゴリ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnファミリ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnタイプ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnキーノート;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnキーノート名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn cln配置数;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnサイズ確認結果;
    }
}