using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGDXTranslator {
    public partial class ProgressForm : Form {

        private String _Label;
        private int _WorkTick = 0;
        public event EventHandler<EventArgs> Canceled;

        public ProgressForm(String label = null) {
            InitializeComponent();
            if (label != null) {
                _Label = label;
            }
            else {
                _Label = "Working";
            }
        }

        private void CancelProgressButton_Click(object sender, EventArgs e) {

            EventHandler<EventArgs> ea = Canceled;

            if (ea != null) {
                ea(this, e);
            }
        }

        public void Tick() {
            _WorkTick++;
            if (_WorkTick > 5) {
                _WorkTick = 0;
            }

            String label = _Label;
            for (int i = 0; i < _WorkTick; i++) {
                label += ".";
            }
            ProgressLabel.Text = label;
        }
    }
}
