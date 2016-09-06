import javax.swing.*;
import java.awt.event.*;

@SuppressWarnings("serial")
public class Principal extends JFrame implements ActionListener {

JDesktopPane desktop = new JDesktopPane();
JMenuBar b;
JMenuItem derivadasRR;
JMenuItem derivadasRnR;
JMenuItem jacobiana;
JMenuItem fecha;
JMenuItem ajuda;
Derivadas1 d1;
Derivadas2 d2;
Jacobiano j;
Ajuda a;

public Principal () {
	
	super("Derivadas");
	
	add(desktop);
	b = criaMenus();
	setJMenuBar(b);
	
	
	
	a = new Ajuda();
	
	a.setVisible(false);
	
	pack();
	setVisible(true);
	setExtendedState(JFrame.MAXIMIZED_BOTH); 
	desktop.setDragMode(JDesktopPane.OUTLINE_DRAG_MODE);
	setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
	
}

	JMenuBar criaMenus () {
		
		JMenuBar menu = new JMenuBar();
		JMenu derivadas = new JMenu("Derivadas");
		menu.add(derivadas);
			derivadasRR = new JMenuItem("Derivadas de R --> R");
			derivadas.add(derivadasRR);
			derivadasRnR = new JMenuItem("Derivadas de Rn --> R");
			derivadas.add(derivadasRnR);
			jacobiana = new JMenuItem("Jacobiano");
			derivadas.add(jacobiana);
		ajuda = new JMenuItem("Ajuda");
		menu.add(ajuda);
		fecha = new JMenuItem("Encerrar");
		menu.add(fecha);
		
		derivadasRR.addActionListener(this);
		derivadasRnR.addActionListener(this);
		jacobiana.addActionListener(this);
		fecha.addActionListener(this);
		ajuda.addActionListener(this);
			return menu;
		
	}
	
	public void actionPerformed (ActionEvent e) {
		
		if (e.getSource() == derivadasRR) {
			new Derivadas1(desktop);
		} 
		else if (e.getSource() == derivadasRnR) {
			new Derivadas2(desktop);
		}
		else if (e.getSource() == jacobiana) {
			new Jacobiano(desktop);
		}
		 else if (e.getSource() == fecha) {
			System.exit(0);
		}
		else if (e.getSource() == ajuda) {
			a.setVisible(true);
		}
	}

	public static void main (String args[]){

		new Principal();
		
		
	}

}
