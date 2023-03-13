using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using UCMain;

namespace Gbjproject
{
    public partial class Main : Form
    {
        Point _imageLocation = new Point(20, 8);
        Point _imgHitArea = new Point(20, 8);

        private string dir = null;
        private string subdir = @"\";

        private string id;
        private string pwd;

        public Label Message_Label { get; set; }
        
        public Button[] btn { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        public Main(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Location = new Point(360, 100);

            // 여백주기 => 여백 주지 않을 시 텍스트와 이미지가 겹쳐서 보임.
            tabControl1.Padding = new Point(20, 4);

            // exe파일이 위치한 경로
            dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            dir += subdir;

            // utility class 파일에 파일경로와 실행시킬 dll 파일 이름을 넘겨줌
            var ucc = new utility(dir, "UCMain");

            UserControl uc = ucc.UC();

            // panel1에 dll파일 추가
            panel1.Controls.Add(uc);
            uc.Tag = "UCMain";

            /*utility.BtnControl_func(Btn, "0");*/

            // ButtonForm에 있는 버튼을 panel2에 포함시키기
            ButtonForm bf = new ButtonForm { TopLevel = false, TopMost = true };
            panel2.Controls.Add(bf);
            bf.Show();

            btn = bf.btn;
            bf.tabControl = this.tabControl1;
        }

        #region TreeViewNode에_관련된_Form을_TabControl에_보여주기
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {   
            /*
             *  tag_arr[]
             *  0 : Program Number, 1 : Form Name, 2 : Form Width, 3 : Form Height, 4 : Form Fill, 5 : Program Name(TabPage Text)
             */

            if (((TreeView)sender).SelectedNode == null) return;

            // Method를 실행한 object의 타입을 TreeView로 변환
            // 선택한 노드의 Tag값을 node_tag 변수에 할당
            String node_tag = (String)((TreeView)sender).SelectedNode.Tag;

            // 재확인
            if (node_tag == null) return;

            // tag값을 ':' 기준으로 자른 다음 배열에 넣는다
            String[] tag_arr = node_tag.Split(':');
            if (tag_arr.Length != 6)
            {
                MessageBox.Show("TreeView Tag 정보를 수정해주십시오.");
                return;
            }

            // 객체의 형식정보는 Object에 있는 GetType()메서드를 통해 확인가능
            // 메서드,프로퍼티목록등 객체를 이루는 거의 모든것을 확인가능

            // Assembly => 컴파일을 통해 나온 결과 파일
            // GetExecutingAssembly() => 현재 실행 중인 코드가 포함된 어셈블리를 가져온다. => WindowsFormApp1
            // GetTypes() => 이 어셈블리가 정의되어 있는 형식을 가져온다. => System.Type[]
            // Where() => 조건을 충족하는 입력 시퀀스의 요소를 포함하는 IEnumerable<Type> 이다.
            // '=>' 이것은 람다식 표현이라고 한다. t의 타입은 컴파일러가 알아서 찾아낸다.
            // FirstOrDefault() => Where()의 조건을 충족하면 formType=Where()의 값, 아니면 null
            // tag_arr[1] => 선택한 노드에서 불러올 Form Name

            // WindowFormApp1의 Type 중에서 Form타입 이면서
            // tag_arr[1]이 Form Name과 같은게 있으면
            // formType에 프로젝트명.Form.Name을 할당
            // 없으면 null 반환
            Type formType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(Form) && t.Name == tag_arr[1])
                .FirstOrDefault();

            if (formType == null)
            {
                MessageBox.Show(tag_arr[5] + " 수행 프로그램이 존재하지 않습니다.");
                return; 
            }

            // 동적으로 formType instance를 생성
            // instance 생성하려면 System.Activator 클래스를 사용해야 한다.
            Form form = (Form)Activator.CreateInstance(formType);
            if (form == null)
            {
                MessageBox.Show(tag_arr[5] + " 수행 프로그램이 존재하지 않습니다.");
                return;
            }

            TabPage tabPage = tabControl1.TabPages[tag_arr[5]];
            if ( tabPage != null)
            {
                tabControl1.SelectTab(tabPage);
                return;
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            if (tag_arr[4].Equals("Y"))
                form.Dock = DockStyle.Fill;

            //TabControl에 TabPage를 추가하고 TabPage text와 찾을때 사용할 key를 추가
            tabControl1.TabPages.Add(tag_arr[5], tag_arr[5]);

            if (tabControl1.TabPages.Count == 0)
            {
                tabControl1.TabPages[0].Controls.Add(form);
                tabControl1.SelectTab(0);
            }
            else
            {
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(form);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
            }

            tab_setValue();

            form.Tag = tag_arr[0];
            form.Show();

            // msg_label.Text = "";
        }
        #endregion

        #region 각_Tab마다_이름은(5,5)_closeImage는(5+TabPage(e.Index).Width-20,8)_위치조정하기
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // (중요!) 이 이벤트가 발생하려면 tabControl의 drawmode속성이 OwnerDrawFixed로 정의되어야만 함

            Rectangle r = e.Bounds;
            
            // 지정한 Tab의 X, Y, Width, Height 값
            r = this.tabControl1.GetTabRect(e.Index);

            // r의 X와 Y 값을 5씩 더한다.
            r.Offset(5, 5);

            Font font = this.Font;
            Brush brush = new SolidBrush(Color.Black);
            string title = this.tabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, font, brush, new PointF(r.X, r.Y));

            // 선택되어있는 TabPage가 아니면 return
            if (e.Index != this.tabControl1.SelectedIndex) return;

            Image img = new Bitmap(Properties.Resources.close);
            e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }
        #endregion

        #region closeImage_공간과_MouseClick한_위치가_범위안이면_해당_Tab_Close하기
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            // 클릭한 위치의 X, Y 값
            Point p = e.Location;

            int _tabWidth = this.tabControl1.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);

            /*
             * 왜 사용했는지 이해 못함
             * r.Width = 32;
             * r.Height = 32;
             */

            // r.X와 r.Y 범위 안에 p.X와 p.Y의 값이 포함될 때 실행
            if (r.Contains(p))
            {
                TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];

                // TabPage 삭제 前에 Form 먼저 Close
                Form form = (Form)tabPage.Controls[0];
                form.Close();

                // 이후 TabPage 삭제
                tabControl.TabPages.Remove(tabPage);
            }
        }
        #endregion

        #region treeView_click하여_새_탭_생성_시_버튼컨트롤_동작하기_위해_btn_값_넘겨주기
        private void tab_setValue()
        {
            if (tabControl1.SelectedTab == null) return;

            // 선택되어 있는 탭의 Form 정보를 저장
            Form form = (Form)tabControl1.SelectedTab.Controls[0];
            // type을 Form 으로 저장
            Type type = form.GetType();

            // type(해당 form)에 btn 이름의 변수에 Parameter Main.btn의 값을 저장
            type.GetProperty("btn")?.SetValue(form, btn);
        }
        #endregion

        #region tab_select_시_탭_별_버튼상태_확인_후_세팅하기
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == null) return;

            // 선택되어 있는 탭의 Form 정보를 저장
            Form form = (Form)tabControl1.SelectedTab.Controls[0];
            // type을 Form 으로 저장
            Type type = form.GetType();

            // type(해당 Form)에 btn_status 이름의 속성을 저장
            PropertyInfo pi = type.GetProperty("btn_status");
            if (pi != null)
            {
                // 해당 form에 있는 btn_status의 값을 가져와 버튼 컨트롤하기
                utility.SetFuncBtn2(btn, pi.GetValue(form) as String);
            }
        }
        #endregion
    }
}
