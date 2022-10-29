
namespace apCidadesMarte
{
    partial class frmCidadesMarte
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCidadesMarte));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcCidadesMarte = new System.Windows.Forms.TabControl();
            this.tpCaminhos = new System.Windows.Forms.TabPage();
            this.ssMensagem = new System.Windows.Forms.StatusStrip();
            this.sslMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.udOpcoes = new System.Windows.Forms.ToolStrip();
            this.btnExibirCidade = new System.Windows.Forms.ToolStripButton();
            this.btnEditarCidade = new System.Windows.Forms.ToolStripButton();
            this.btnIncluirCidade = new System.Windows.Forms.ToolStripButton();
            this.btnExcluirCidade = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.udCusto = new System.Windows.Forms.NumericUpDown();
            this.udTempo = new System.Windows.Forms.NumericUpDown();
            this.udDistancia = new System.Windows.Forms.NumericUpDown();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.lbOrigem = new System.Windows.Forms.Label();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.udY = new System.Windows.Forms.NumericUpDown();
            this.udX = new System.Windows.Forms.NumericUpDown();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpArvore = new System.Windows.Forms.TabPage();
            this.pnlArvore = new System.Windows.Forms.Panel();
            this.dlgAbrirCidades = new System.Windows.Forms.OpenFileDialog();
            this.dlgAbrirCaminhos = new System.Windows.Forms.OpenFileDialog();
            this.tcCidadesMarte.SuspendLayout();
            this.tpCaminhos.SuspendLayout();
            this.ssMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.udOpcoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).BeginInit();
            this.tpArvore.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCidadesMarte
            // 
            this.tcCidadesMarte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCidadesMarte.Controls.Add(this.tpCaminhos);
            this.tcCidadesMarte.Controls.Add(this.tpArvore);
            this.tcCidadesMarte.HotTrack = true;
            this.tcCidadesMarte.Location = new System.Drawing.Point(0, 1);
            this.tcCidadesMarte.Name = "tcCidadesMarte";
            this.tcCidadesMarte.SelectedIndex = 0;
            this.tcCidadesMarte.Size = new System.Drawing.Size(1200, 692);
            this.tcCidadesMarte.TabIndex = 0;
            // 
            // tpCaminhos
            // 
            this.tpCaminhos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tpCaminhos.Controls.Add(this.ssMensagem);
            this.tpCaminhos.Controls.Add(this.pbMapa);
            this.tpCaminhos.Controls.Add(this.udOpcoes);
            this.tpCaminhos.Controls.Add(this.groupBox2);
            this.tpCaminhos.Controls.Add(this.groupBox1);
            this.tpCaminhos.Location = new System.Drawing.Point(4, 29);
            this.tpCaminhos.Name = "tpCaminhos";
            this.tpCaminhos.Padding = new System.Windows.Forms.Padding(3);
            this.tpCaminhos.Size = new System.Drawing.Size(1192, 659);
            this.tpCaminhos.TabIndex = 0;
            this.tpCaminhos.Text = "Gerenciar Caminhos";
            // 
            // ssMensagem
            // 
            this.ssMensagem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ssMensagem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMensagem});
            this.ssMensagem.Location = new System.Drawing.Point(3, 634);
            this.ssMensagem.Name = "ssMensagem";
            this.ssMensagem.Size = new System.Drawing.Size(1186, 22);
            this.ssMensagem.TabIndex = 13;
            this.ssMensagem.Text = "statusStrip1";
            // 
            // sslMensagem
            // 
            this.sslMensagem.Name = "sslMensagem";
            this.sslMensagem.Size = new System.Drawing.Size(0, 17);
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.Image = ((System.Drawing.Image)(resources.GetObject("pbMapa.Image")));
            this.pbMapa.Location = new System.Drawing.Point(438, 132);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(758, 499);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 12;
            this.pbMapa.TabStop = false;
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // udOpcoes
            // 
            this.udOpcoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.udOpcoes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.udOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExibirCidade,
            this.btnEditarCidade,
            this.btnIncluirCidade,
            this.btnExcluirCidade,
            this.toolStripSeparator2,
            this.btnCancelar,
            this.btnSalvar,
            this.toolStripSeparator5,
            this.btnSair});
            this.udOpcoes.Location = new System.Drawing.Point(3, 3);
            this.udOpcoes.Name = "udOpcoes";
            this.udOpcoes.Size = new System.Drawing.Size(1186, 42);
            this.udOpcoes.TabIndex = 11;
            this.udOpcoes.Text = "toolStrip1";
            // 
            // btnExibirCidade
            // 
            this.btnExibirCidade.Enabled = false;
            this.btnExibirCidade.Image = ((System.Drawing.Image)(resources.GetObject("btnExibirCidade.Image")));
            this.btnExibirCidade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExibirCidade.Name = "btnExibirCidade";
            this.btnExibirCidade.Size = new System.Drawing.Size(40, 39);
            this.btnExibirCidade.Text = "Exibir";
            this.btnExibirCidade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExibirCidade.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // btnEditarCidade
            // 
            this.btnEditarCidade.Enabled = false;
            this.btnEditarCidade.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCidade.Image")));
            this.btnEditarCidade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarCidade.Name = "btnEditarCidade";
            this.btnEditarCidade.Size = new System.Drawing.Size(41, 39);
            this.btnEditarCidade.Text = "Editar";
            this.btnEditarCidade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditarCidade.Click += new System.EventHandler(this.btnEditarCidade_Click);
            // 
            // btnIncluirCidade
            // 
            this.btnIncluirCidade.Enabled = false;
            this.btnIncluirCidade.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluirCidade.Image")));
            this.btnIncluirCidade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIncluirCidade.Name = "btnIncluirCidade";
            this.btnIncluirCidade.Size = new System.Drawing.Size(44, 39);
            this.btnIncluirCidade.Text = "Incluir";
            this.btnIncluirCidade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIncluirCidade.Click += new System.EventHandler(this.btnIncluirCidade_Click);
            // 
            // btnExcluirCidade
            // 
            this.btnExcluirCidade.Enabled = false;
            this.btnExcluirCidade.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirCidade.Image")));
            this.btnExcluirCidade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluirCidade.Name = "btnExcluirCidade";
            this.btnExcluirCidade.Size = new System.Drawing.Size(46, 39);
            this.btnExcluirCidade.Text = "Excluir";
            this.btnExcluirCidade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluirCidade.Click += new System.EventHandler(this.btnExcluirCidade_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 39);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(42, 39);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(30, 39);
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.udCusto);
            this.groupBox2.Controls.Add(this.udTempo);
            this.groupBox2.Controls.Add(this.udDistancia);
            this.groupBox2.Controls.Add(this.txtOrigem);
            this.groupBox2.Controls.Add(this.lbOrigem);
            this.groupBox2.Controls.Add(this.btnExcluirCaminho);
            this.groupBox2.Controls.Add(this.btnAlterar);
            this.groupBox2.Controls.Add(this.btnIncluirCaminho);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dgvCaminhos);
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 505);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caminhos";
            // 
            // udCusto
            // 
            this.udCusto.Location = new System.Drawing.Point(92, 172);
            this.udCusto.Name = "udCusto";
            this.udCusto.Size = new System.Drawing.Size(183, 26);
            this.udCusto.TabIndex = 30;
            // 
            // udTempo
            // 
            this.udTempo.Location = new System.Drawing.Point(92, 137);
            this.udTempo.Name = "udTempo";
            this.udTempo.Size = new System.Drawing.Size(183, 26);
            this.udTempo.TabIndex = 29;
            // 
            // udDistancia
            // 
            this.udDistancia.Location = new System.Drawing.Point(92, 102);
            this.udDistancia.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.udDistancia.Name = "udDistancia";
            this.udDistancia.Size = new System.Drawing.Size(183, 26);
            this.udDistancia.TabIndex = 28;
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(92, 28);
            this.txtOrigem.MaxLength = 15;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(183, 26);
            this.txtOrigem.TabIndex = 27;
            // 
            // lbOrigem
            // 
            this.lbOrigem.AutoSize = true;
            this.lbOrigem.Location = new System.Drawing.Point(8, 31);
            this.lbOrigem.Name = "lbOrigem";
            this.lbOrigem.Size = new System.Drawing.Size(64, 20);
            this.lbOrigem.TabIndex = 26;
            this.lbOrigem.Text = "Origem:";
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.Location = new System.Drawing.Point(281, 120);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(131, 40);
            this.btnExcluirCaminho.TabIndex = 25;
            this.btnExcluirCaminho.Text = "Excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = true;
            this.btnExcluirCaminho.Click += new System.EventHandler(this.btnExcluirCaminho_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(281, 74);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(131, 40);
            this.btnAlterar.TabIndex = 24;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.Location = new System.Drawing.Point(281, 28);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(131, 40);
            this.btnIncluirCaminho.TabIndex = 23;
            this.btnIncluirCaminho.Text = "Incluir";
            this.btnIncluirCaminho.UseVisualStyleBackColor = true;
            this.btnIncluirCaminho.Click += new System.EventHandler(this.btnIncluirCaminho_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Custo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Tempo: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Distância:";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(92, 66);
            this.txtDestino.MaxLength = 15;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(183, 26);
            this.txtDestino.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Destino:";
            // 
            // dgvCaminhos
            // 
            this.dgvCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destino,
            this.Distancia,
            this.Tempo,
            this.Custo});
            this.dgvCaminhos.Location = new System.Drawing.Point(6, 206);
            this.dgvCaminhos.Name = "dgvCaminhos";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCaminhos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaminhos.Size = new System.Drawing.Size(406, 290);
            this.dgvCaminhos.TabIndex = 11;
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            // 
            // Distancia
            // 
            this.Distancia.HeaderText = "Distância";
            this.Distancia.Name = "Distancia";
            // 
            // Tempo
            // 
            this.Tempo.HeaderText = "Tempo";
            this.Tempo.Name = "Tempo";
            this.Tempo.Width = 65;
            // 
            // Custo
            // 
            this.Custo.HeaderText = "Custo";
            this.Custo.Name = "Custo";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.udY);
            this.groupBox1.Controls.Add(this.udX);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1186, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações da Cidade";
            // 
            // udY
            // 
            this.udY.DecimalPlaces = 5;
            this.udY.Enabled = false;
            this.udY.Location = new System.Drawing.Point(672, 29);
            this.udY.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udY.Name = "udY";
            this.udY.ReadOnly = true;
            this.udY.Size = new System.Drawing.Size(120, 26);
            this.udY.TabIndex = 15;
            // 
            // udX
            // 
            this.udX.DecimalPlaces = 5;
            this.udX.Enabled = false;
            this.udX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.udX.Location = new System.Drawing.Point(428, 29);
            this.udX.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udX.Name = "udX";
            this.udX.ReadOnly = true;
            this.udX.Size = new System.Drawing.Size(120, 26);
            this.udX.TabIndex = 14;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(146, 28);
            this.txtNome.MaxLength = 15;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(158, 26);
            this.txtNome.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Coordenada y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Coordenada x:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome da cidade:";
            // 
            // tpArvore
            // 
            this.tpArvore.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tpArvore.Controls.Add(this.pnlArvore);
            this.tpArvore.Location = new System.Drawing.Point(4, 29);
            this.tpArvore.Name = "tpArvore";
            this.tpArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tpArvore.Size = new System.Drawing.Size(1192, 659);
            this.tpArvore.TabIndex = 1;
            this.tpArvore.Text = "Visualizar Cidades";
            this.tpArvore.Enter += new System.EventHandler(this.tpArvore_Enter);
            // 
            // pnlArvore
            // 
            this.pnlArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArvore.Location = new System.Drawing.Point(6, 6);
            this.pnlArvore.Name = "pnlArvore";
            this.pnlArvore.Size = new System.Drawing.Size(1183, 650);
            this.pnlArvore.TabIndex = 0;
            this.pnlArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlArvore_Paint);
            // 
            // dlgAbrirCidades
            // 
            this.dlgAbrirCidades.FileName = "openFileDialog1";
            // 
            // dlgAbrirCaminhos
            // 
            this.dlgAbrirCaminhos.FileName = "openFileDialog1";
            // 
            // frmCidadesMarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tcCidadesMarte);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmCidadesMarte";
            this.Text = "Caminhos entre Cidades de Marte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCidadesMarte_FormClosing);
            this.Load += new System.EventHandler(this.frmCidadesMarte_Load);
            this.Resize += new System.EventHandler(this.frmCidadesMarte_Resize);
            this.tcCidadesMarte.ResumeLayout(false);
            this.tpCaminhos.ResumeLayout(false);
            this.tpCaminhos.PerformLayout();
            this.ssMensagem.ResumeLayout(false);
            this.ssMensagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.udOpcoes.ResumeLayout(false);
            this.udOpcoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udX)).EndInit();
            this.tpArvore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcCidadesMarte;
        private System.Windows.Forms.TabPage tpCaminhos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udY;
        private System.Windows.Forms.NumericUpDown udX;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpArvore;
        private System.Windows.Forms.StatusStrip ssMensagem;
        private System.Windows.Forms.ToolStripStatusLabel sslMensagem;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.ToolStrip udOpcoes;
        private System.Windows.Forms.ToolStripButton btnIncluirCidade;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExcluirCidade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExcluirCaminho;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Custo;
        private System.Windows.Forms.OpenFileDialog dlgAbrirCidades;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label lbOrigem;
        private System.Windows.Forms.ToolStripButton btnExibirCidade;
        private System.Windows.Forms.ToolStripButton btnEditarCidade;
        private System.Windows.Forms.Panel pnlArvore;
        private System.Windows.Forms.NumericUpDown udCusto;
        private System.Windows.Forms.NumericUpDown udTempo;
        private System.Windows.Forms.NumericUpDown udDistancia;
        private System.Windows.Forms.OpenFileDialog dlgAbrirCaminhos;
    }
}

