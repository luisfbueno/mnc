import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
//Terminado, funÃ§Ãµes implementadas e funcionais
@SuppressWarnings("serial")
class Jacobiano extends JInternalFrame implements ActionListener {

JTextField n = new JTextField(5);
JTextField m = new JTextField(5);
JTextField epsilon = new JTextField(5);
JTextField[] x = new JTextField[10];
JTextField[] fx = new JTextField[10];
JTextField[][] jacob = new JTextField[10][10];
JButton calc = new JButton("Calcula");
JButton monta = new JButton("Monta");
Expressao exp = new Expressao();
JPanel meio;
int i,j;
int lin,col;
String[] funcs = new String[10];
double[] xval = new double[10]; 

Jacobiano(JDesktopPane desktop) {
		
	super("Jacobiano");
	
	for(i=0;i<10;i++){
		x[i] = new JTextField(5);
		fx[i] = new JTextField(25);
	}
	
	for(i=0;i<10;i++){
		for(j=0;j<10;j++){
			jacob[i][j] = new JTextField(10);
			(jacob[i][j]).setEditable(false);
		}
	}
	
	
	setLayout(new BorderLayout());

	JPanel entr = new JPanel();
	entr.add(new JLabel("m ="));
	m.setText("3");
	entr.add(m);
	entr.add(new JLabel("n ="));
	n.setText("3");
	entr.add(n);
	monta.addActionListener(this);
	entr.add(monta);
	entr.add(new JLabel("ε = "));
	epsilon.setText("0.00001"); 
	entr.add(epsilon);
	calc.addActionListener(this);
	entr.add(calc);
	add(entr,BorderLayout.NORTH);
	meio = criaPanelGrades(3,3,fx,x,jacob);
	(x[0]).setText("1");
	(x[1]).setText("1");
	(x[2]).setText("1");
	(fx[0]).setText("sin(x[1])+sin(x[2])+sin(x[3])");
	(fx[1]).setText("x[1]*x[2]+x[1]*x[3]+x[2]*x[3]");
	(fx[2]).setText("x[1]^3+x[2]*(x[3]^2)");
	add(meio,BorderLayout.WEST);
	pack();
	setVisible(true);
	setIconifiable(true);
	setClosable(true);
	desktop.add(this);
	setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

}

JPanel criaPanelGrades (int m,int n,JTextField fx[],JTextField x[],JTextField jacob[][]) {
	
	int i,j;
	
	JPanel vetx = new JPanel();
	JPanel vetf = new JPanel();
	JPanel mat = new JPanel();
	JPanel pFinal = new JPanel();
	BorderLayout l = new BorderLayout();
	l.setVgap(30);
	l.setHgap(10);
	vetx.setLayout(new GridBagLayout());
	vetf.setLayout(new GridBagLayout());
	mat.setLayout(new GridBagLayout());
	pFinal.setLayout(l);
	GridBagConstraints c = new GridBagConstraints();
	
	//CRIAÃ‡ÃƒO DO PANEL COM VETOR DE VALORES DE X
	
	c.gridy=0;
	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vetx.add(new JLabel(i +" "),c);
	}
	
	c.gridy=1;
	c.gridx=0;
	vetx.add(new JLabel("Vetor X[n]"),c);

	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vetx.add(x[i-1],c);
	}
	
	//CRIAÃ‡ÃƒO DO VETOR DE FUNÃ‡Ã•ES
	
	c.gridx=0;
	c.gridy=0;

	
	vetf.add(new JLabel("Vetor F[m]"),c);
	
	for(i=1;i<=m;i++){
		
		c.gridy=i;
		vetf.add(new JLabel(i + " "),c);
		
	}
	
	c.gridx=1;
	
	for(i=1;i<=m;i++){
		c.gridy=i;
		vetf.add(fx[i-1],c);
		
	}
	
	//CRIAÃ‡AO DA MATRIZ JACOBIANO
	
	c.gridx=0;
	c.gridy=0;
	
	mat.add(new JLabel("Jacobiano [m][n]"),c);
	
	for(i=1;i<=n;i++){ //linha de numeros
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = i;
		c.gridy = 0;
		mat.add(new JLabel(i+" "), c);
		
	}
	
	for(i=1;i<=m;i++){ //coluna de numeros
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = 0;
		c.gridy = i;
		mat.add(new JLabel(i+" "), c);
	}
	
	for(i=1;i<=m;i++){ //matriz de jtextfields
		for(j=1;j<=n;j++){
			c.gridx = j;
			c.gridy = i;
			mat.add(jacob[i-1][j-1], c);
		}
	}
			
			
	pFinal.add(vetx,BorderLayout.NORTH);
	pFinal.add(vetf,BorderLayout.CENTER);
	pFinal.add(mat,BorderLayout.SOUTH);
	
	return pFinal;
	
	
}
//-----------------------------------------------------------------------------------------------------------------------------------
double f (String func,double v,int ind) { //funÃ§Ã£o q retorna valor da funÃ§Ã£o func para um certo valor v de indice ind (uma variavel)
	
	double num=0;
	exp.variavel("x["+ind+"]",v);
	
	try{
		num = exp.valor(func);
	}catch(Exception E) {}
	
	return num;
}
//------------------------------------------------------------------------------------------------------------------------------------
void passaFieldDouble (JTextField x[],double xval[],int n) { //passa os valores nos text fields x[i] para vetor de double e seta valores na expressao
															//de acordo com os valores de xval[i]
		int i = 0,j;
		
		for(i = 0;i<n;i++){
				xval[i] = Double.parseDouble(x[i].getText());
				j=i+1;
				exp.variavel("x["+ j +"]",xval[i]);
		}
}
//------------------------------------------------------------------------------------------------------------------------------------
double derivadaParcial (String fexp,double eps,int i,double x[]){ //funÃ§Ã£o que calcula derivada parcial baseado em x[i] para o Gradiente
	
	double d = 0;
	double h = 1000*eps;
	boolean achou = false;
	double p=0,q;
	double f1,f2,xi; //variaveis que guardam valores das funÃ§Ãµes
	int it;
	
	xi=x[i]; //passa x[i] para uma variÃ¡vel auxiliar para restaurar no final
	x[i] = xi + h;
	f1 = f(fexp,x[i],i+1); //passando ind como i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] )
	x[i] = xi - h;
	f2 = f(fexp,x[i],i+1); //passando ind como i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] )
	
	p = (f1-f2)/(2*h);
	
	for(it=0;it<10 && !achou;it++) { //mÃ¡ximo de dez iteraÃ§Ãµes
		
		q=p;
		h=h/2;
		
		x[i] = xi + h;
		f1 = f(fexp,x[i],i+1);
		x[i] = xi - h;
		f2 = f(fexp,x[i],i+1);
	
		p = (f1-f2)/(2*h);
		
		if(Math.abs(p-q) < eps)		
			achou=true;
			

	}
	
	x[i]=xi; //reseta valor de x[i] na expressÃ£o E no vetor para nao dar erro de valor na prÃ³xima expressÃ£o
	exp.variavel("x["+(i+1)+"]",xi); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
	d=p;
	
	return d;
}
//------------------------------------------------------------------------------------------------------------------------------------
void passaFieldString (JTextField x[],String alvo[],int n) { //passa os valores nos text fields x[i] para vetor de double e seta valores na expressao
															//de acordo com os valores de xval[i]
		int i = 0;
		
		for(i=0;i<=n;i++)
				alvo[i] = x[i].getText();

}


public void actionPerformed (ActionEvent e) {
	
	Container frame = null;
	
	try{
		lin = Integer.parseInt(m.getText());
		col = Integer.parseInt(n.getText());
	}catch(NumberFormatException EX) {
		JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaÃ§o foi deixado em branco ou se os numeros foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
	}
	
	
	if(e.getSource()==monta){
		
		remove(meio);
		meio = criaPanelGrades(lin,col,fx,x,jacob);
		add(meio,BorderLayout.WEST);
		pack();
	}
	
	else if(e.getSource()==calc) {
		
		double aux = 0;
		double eps = 0;
		try{
		passaFieldString(fx,funcs,lin);
		passaFieldDouble(x,xval,col);
		}catch(NumberFormatException EX) {
			JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
		}
		
		try{
		eps = Double.parseDouble(epsilon.getText());
		}catch(NumberFormatException EX) {
		JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaÃ§o foi deixado em branco ou se os numeros foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
	}
			
			
		for(i=0;i<lin;i++){
			for(j=0;j<col;j++){
				aux=derivadaParcial(funcs[i],eps,j,xval);
				(jacob[i][j]).setText(String.valueOf(aux));
				}
			}	
		
		}
		

	}	

}



