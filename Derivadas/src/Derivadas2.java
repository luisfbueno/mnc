import javax.swing.JPanel;
import javax.swing.JFrame;
import javax.swing.JTextField;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
//Terminado, funÃ§Ãµes implementadas e funcionais
@SuppressWarnings("serial")
class Derivadas2 extends JInternalFrame implements ActionListener {

JTextField fx = new JTextField(20);
JTextField n = new JTextField(5);
JTextField epsilon = new JTextField(5);
JTextField[] x = new JTextField[10];
JTextField[] g = new JTextField[10];
JTextField[][] h = new JTextField[10][10];
JPanel grades; //JPanel que recebera o retorno da funÃ§Ã£o painelGradHess
JButton b = new JButton("Calcula");
JButton monta = new JButton("Monta");
Expressao exp = new Expressao(); //FunÃ§Ã£o expressÃ£o - Interpretador
int i,j,num;
double[] xval = new double[10]; //

Derivadas2(JDesktopPane desktop) { //Construtor
	
	super("Rn -> R");
	
	for(i=0;i<10;i++){
		x[i]=new JTextField(6);
		g[i]=new JTextField(6);
		(g[i]).setEditable(false);
		for(j=0;j<10;j++)
			h[i][j] = new JTextField(6);
			//(h[i][j]).setEditable(false);
	}
	
	for(i=0;i<10;i++)
		for(j=0;j<10;j++)
			(h[i][j]).setEditable(false);
	
	setLayout(new BorderLayout());

	//painel com entradas da funÃ§Ã£o, n e epsilon
	JPanel func = new JPanel();
	func.add(new JLabel("n = ")); 
	n.setText("2"); //prÃ©-determina valor para facilitar teste
	func.add(n);
	monta.addActionListener(this);
	func.add(monta);
	func.add(new JLabel("f(x) = ")); 
	fx.setText("x[1]*x[1] + x[2]*x[2] + x[1]*x[2]"); //prÃ©-determina valor para facilitar teste
	func.add(fx);
	func.add(new JLabel("ε = ")); 
	epsilon.setText("0.001"); //prÃ©-determina valor para facilitar teste
	func.add(epsilon);
	func.add(b);
	b.addActionListener(this);
	//painel que recebe x[i],gradiente e hessiana
	//JPanel panel = new JPanel(new BorderLayout());
	add(func,BorderLayout.NORTH);
	num = Integer.parseInt(n.getText());
	grades = painelGradHess(num,x,g,h);
	(x[0]).setText("2");
	(x[1]).setText("3");
	add(grades,BorderLayout.CENTER);
	pack();
	setVisible(true);
	setIconifiable(true);
	setClosable(true);
	desktop.add(this);
	setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

}
//------------------------------------------------------------------------------------------------------------------------------------
JPanel painelGradHess (int n,JTextField xi[],JTextField grad[],JTextField hess[][]) { //funÃ§Ã£o que cria painel com os vetores e matriz
	
	JPanel p = new JPanel();
	JPanel g = new JPanel();
	JPanel h = new JPanel();
	JPanel x = new JPanel();
	BorderLayout l = new BorderLayout();
	l.setVgap(30);
	l.setHgap(10);
	p.setLayout(l);
	g.setLayout(new GridBagLayout());
	h.setLayout(new GridBagLayout());
	x.setLayout(new GridBagLayout());
	GridBagConstraints c = new GridBagConstraints();
	
	//CRIAÃ‡ÃƒO DO VETOR X[I]
	
	for(i=1;i<=n;i++){
		c.gridx = i;
		c.gridy = 0;
		x.add(new JLabel(i+" "), c);
		
		
	}
	
	c.gridx = 0;
	c.gridy = 1;
	x.add(new JLabel("Vetor X[i]"), c);
	
	for(i=1;i<=n;i++){
		c.gridx = i;
		c.gridy = 1;
		x.add(xi[i-1], c);
			
	}
	
	//CRIAÃ‡ÃƒO DO VETOR GRADIENTE
	
	for(i=1;i<=n;i++){
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = i;
		c.gridy = 0;
		g.add(new JLabel(i+" "), c);
		
		
	}
	
	c.gridx = 0;
	c.gridy = 1;
	g.add(new JLabel("Vetor Gradiente[i]"), c);
	
	for(i=1;i<=n;i++){
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = i;
		c.gridy = 1;
		g.add(grad[i-1], c);
			
	}
	
	
	//CRIAÃ‡ÃƒO DA MATRIZ HESSIANA
	
	c.gridx = 0;
	c.gridy = 0;
	h.add(new JLabel("Hessiana [i][j]"), c);
	for(i=1;i<=n;i++){ //linha de numeros
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = i;
		c.gridy = 0;
		h.add(new JLabel(i+" "), c);
		
	}
	
	for(i=1;i<=n;i++){ //coluna de numeros
		//c.fill = GridBagConstraints.HORIZONTAL;
		c.gridx = 0;
		c.gridy = i;
		h.add(new JLabel(i+" "), c);
	}
	
	for(i=1;i<=n;i++){ //matriz de jtextfields
		for(j=1;j<=n;j++){
			c.gridx = j;
			c.gridy = i;
			h.add(hess[i-1][j-1], c);
		}
	}
	
	p.add(x,BorderLayout.NORTH);
	p.add(g,BorderLayout.CENTER);
	p.add(h,BorderLayout.SOUTH);
	add(p);
	
	pack();
	setVisible(true);
	
	return p;

}
//------------------------------------------------------------------------------------------------------------------------------------
double f (String func,double v,int ind) { //funÃ§Ã£o q retorna valor da funÃ§Ã£o func para um certo valor v de indice ind (uma variavel)
	
	double num=0;
	exp.variavel("x["+ind+"]",v);
	
	try{
		num = exp.valor(func);
	}catch(Exception E) {}
	
	return num;
}
//------------------------------------------------------------------------------------------------------------------------------------
double f (String func,double xi,double xj,int i,int j) { //Overload de f para o caso de duas variaveis
	
	double num=0;
	exp.variavel("x["+i+"]",xi);
	exp.variavel("x["+j+"]",xj);
	
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
double derivadaParcialSegunda (String fexp,double eps,int i,int j,double x[]){
	
	int it;
	boolean achou = false;
	double h = 1000*eps;
	double xi,xj;
	double d=0;
	double f1,f2,f3,f4,p,q;
	
	xi=x[i];
	xj=x[j];
	
	if(i!=j){
		
		x[i] = xi+h;
		x[j] = xj+h;
		f1=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		x[j]=xj-h;
		f2=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		x[i] = xi-h;
		f4=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		x[j]=xj+h;
		f3=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		p=(f1-f2-f3+f4)/(4*h*h); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
	}
	else{
		
		x[i]=xi+2*h;
		f1=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		x[i]=xi-2*h;
		f3=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		x[i]=xi;
		f2=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
		p=(f1-2*f2+f3)/(4*h*h);
	}
	
	for(it=0;it<10 && !achou;it++){
		
		q=p;
		h=h/2;
		
		if(i!=j){
		
			x[i] = xi+h;
			x[j] = xj+h;
			f1=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
			x[j]=xj-h;
			f2=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
			x[i] = xi-h;
			f4=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
			x[j]=xj+h;
			f3=f(fexp,x[i],x[j],i+1,j+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
		
			p=(f1-f2-f3+f4)/(4*h*h);	
		}
		
		else{
			
			exp.variavel("x["+(j+1)+"]",xj);
		
			x[i]=xi+2*h;
			f1=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
			
			x[i]=xi-2*h;
			f3=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
			
			x[i]=xi;
			f2=f(fexp,x[i],i+1); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
			
			p=(f1-2*f2+f3)/(4*h*h);
			}
		
		if(Math.abs(p-q)<eps)
			achou = true;
		
		
	}
	
	d=p;
	x[i]=xi; //reseta valor de x[i] e x[j] na expressÃ£o E no vetor para nao dar erro de valor na prÃ³xima expressÃ£o
	x[j]=xj;
	
	exp.variavel("x["+(i+1)+"]",x[i]); //passando para i+1 na expressÃ£o pois a posiÃ§Ã£o i do vetor indica i+1 na expressÃ£o (x[i] da exp == xval[i-1] ) 
	exp.variavel("x["+(j+1)+"]",x[j]);
	
	return d;
	
}
//------------------------------------------------------------------------------------------------------------------------------------
public void actionPerformed (ActionEvent e) {
	
	String fexp = null;
	double eps = 0;
	double aux = 0;
	Container frame = null;
	
	if(e.getSource()==b){ //botao de calcular
		
	try{
		passaFieldDouble(x,xval,num);
		eps = Double.parseDouble(epsilon.getText());
		fexp = fx.getText();
	}catch(NumberFormatException EX) {
		JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaÃ§o foi deixado em branco ou se os numeros foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
	}
		
		for(i=0;i<num;i++){
			aux=derivadaParcial(fexp,eps,i,xval);
			(g[i]).setText(String.valueOf(aux));
		}
		
		for(i=0;i<num;i++){
			for(j=0;j<num;j++){
				aux=derivadaParcialSegunda(fexp,eps,i,j,xval);
				(h[i][j]).setText(String.valueOf(aux));
			}
		}
		
	}
	
	else if(e.getSource()==monta){ //botao que monta os vetores e a matriz
	
	try{
		num = Integer.parseInt(n.getText());
	}catch(NumberFormatException EX) {
		JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaÃ§o foi deixado em branco ou se os numeros foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
	}	
	
		remove(grades);
		grades = painelGradHess(num,x,g,h);
		add(grades,BorderLayout.CENTER);
		pack();
		
		}
	
	}
}
