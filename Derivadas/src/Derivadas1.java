import javax.swing.JPanel;
import javax.swing.JTextField;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
//Terminado, funÃ§Ãµes implementadas e funcionais
@SuppressWarnings("serial")
class Derivadas1 extends JInternalFrame implements ActionListener {

JTextField fx = new JTextField(30);
JTextField vx = new JTextField(5);
JTextField epsilon = new JTextField(5);
JTextField d1 = new JTextField(12);
JTextField d2 = new JTextField(12);
JTextField d3 = new JTextField(12);
JTextField d4 = new JTextField(12);
JButton b = new JButton("Calcula");
Expressao exp = new Expressao();


Derivadas1(JDesktopPane desktop) {
	
	super("R --> R");

	setLayout(new BorderLayout());

	//painel com entradas de valores
	JPanel func = new JPanel();
	func.add(new JLabel("f(x) = ")); 
	func.add(fx);
	fx.setText("x^5 - 4*(x^4) + 3*(x^3) + (x^2)/2 + 5*x - 2");
	func.add(new JLabel("x = ")); 
	func.add(vx);
	vx.setText("2");
	func.add(new JLabel("ε = ")); 
	func.add(epsilon);
	epsilon.setText("0.001");
	func.add(b);
	b.addActionListener(this);
	//painel com saÃ­da de valores
	JPanel d = new JPanel();
	d.add(new JLabel("f'(x) = ")); 
	d1.setEditable(false);
	d1.setBorder(javax.swing.BorderFactory.createEmptyBorder());
	d.add(d1);
	d.add(new JLabel("f''(x) = ")); 
	d2.setEditable(false);
	d2.setBorder(javax.swing.BorderFactory.createEmptyBorder());
	d.add(d2);
	d.add(new JLabel("f'''(x) = ")); 
	d3.setEditable(false);
	d3.setBorder(javax.swing.BorderFactory.createEmptyBorder());
	d.add(d3);
	d.add(new JLabel("f'''(x) = ")); 
	d4.setEditable(false);
	d4.setBorder(javax.swing.BorderFactory.createEmptyBorder());
	d.add(d4);
	add(d,BorderLayout.CENTER);
	add(func,BorderLayout.NORTH);
	pack();
	setVisible(true);
	setIconifiable(true);
	setClosable(true);
	desktop.add(this);
	setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);


}

//funÃ§Ã£o q retorna valor da funÃ§Ã£o para um certo valor
double f (String func,double v) {
	
	double num=0;
	exp.variavel("x",v);
	
	try{
		num = exp.valor(func);
	}catch(Exception E) {}
	
	return num;
}
/*
//funÃ§Ã£o de derivada para ordens 1,2,3,4(Determinado pela variÃ¡vel ordem que multiplica h) --> VERSAO CURTA
double derivada (String fexp,double eps,double ordem,double x){
	
	double d = 0;
	double h = 1000*eps;
	boolean achou = false;
	double p,q;
	int it = 0;
	
	p = ( f(fexp,x+h) - f(fexp,x-h) )/(2*h);
	
	for(it=0;it<10 && !achou;it++) {
		
		//q = ( f(fexp,x+h) + f(fexp,x-h) )/2*h;
		q=p;
		h=h/2;
		p = ( f(fexp,x+h) + f(fexp,x-h) )/(2*h);
		
		if(Math.abs(p-q) < eps)
			achou = true;
		
	}
	
	
	d=p;
	
	return d;
}
*/

//funÃ§Ã£o de derivada para ordens 1,2,3,4(Determinado pela variÃ¡vel ordem que multiplica h) --> VERSAO MAIOR
double derivada (String fexp,double eps,double ordem,double x){
	
	double d = 0;
	double h = 1000*eps;
	boolean achou = false;
	double p=0,q;
	int it = 0;
	double erro = 1000000;
	int maxIt = 100;
	
	if(ordem == 1)
		p = ( f(fexp,x+h) - f(fexp,x-h) )/(2*h);
	else if(ordem == 2)
		p = ( f(fexp,x+2*h) - 2 * f(fexp,x) + f(fexp,x-2*h) )/(4*h*h);
	else if(ordem == 3)
		p = ( f(fexp,x+3*h) - 3* f(fexp,x+h) + 3*f(fexp,x-h) - f(fexp,x-3*h) )/(8*h*h*h);
	else if(ordem == 4)
		p = ( f(fexp,x+ 4*h) - 4*f(fexp,x+2*h) + 6*f(fexp,x) - 4*f(fexp,x-2*h) + f(fexp,x- 4*h) )/(16*h*h*h*h);
	
	for(it=0;it<maxIt && !achou;it++) {
		
		q=p;
		h=h/2;
		if(ordem == 1)
			p = ( f(fexp,x+h) - f(fexp,x-h) )/(2*h);
		else if(ordem == 2)
			p = ( f(fexp,x+2*h) - 2 * f(fexp,x) + f(fexp,x-2*h) )/(4*h*h);
		else if(ordem == 3)
			p = ( f(fexp,x+3*h) - 3* f(fexp,x+h) + 3*f(fexp,x-h) - f(fexp,x-3*h) )/(8*h*h*h);
		else if(ordem == 4)
			p = ( f(fexp,x+ 4*h) - 4*f(fexp,x+2*h) + 6*f(fexp,x) - 4*f(fexp,x-2*h) + f(fexp,x- 4*h) )/(16*h*h*h*h);
		
		System.out.println("k - " + it + "/p - " + p + "/q- " + q);
		
		if(Math.abs(p-q) < erro)
			erro=Math.abs(p-q);
		else{
			d=q;
			achou=true;
			}
		
		if(Math.abs(p-q)<eps){
			d=p;
			achou=true;
			}
	}
	
	
	return d;
}

public void actionPerformed (ActionEvent e) {
	
	String fexp = null;
	double de1 = 0,de2 = 0,de3 = 0,de4 = 0;
	double x=0, eps=0;
	Container frame = null;
	
	if(e.getSource()==b){
		
	try{
		x = Double.parseDouble(vx.getText());
		eps = Double.parseDouble(epsilon.getText());
		fexp = fx.getText();
	}catch(NumberFormatException EX) {
		JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
	}
		
		try{
			de1 = derivada(fexp,eps,1,x);
			de2 = derivada(fexp,eps,2,x);
			de3 = derivada(fexp,eps,3,x);
			de4 = derivada(fexp,eps,4,x);
		}catch(Exception ex) {
			//JOptionPane.showMessageDialog(frame = new Container(), "Erro na operaÃ§Ã£o", "Aviso!",JOptionPane.ERROR_MESSAGE);
		}
		d1.setText(String.valueOf(de1));
		d2.setText(String.valueOf(de2));
		d3.setText(String.valueOf(de3));
		d4.setText(String.valueOf(de4));
		}
		
	}
	
	
	
}

