import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;
import java.math.BigDecimal;

@SuppressWarnings("serial")
public class Raizes extends JFrame implements ActionListener {

JTextField fx = new JTextField(15);
JTextField a = new JTextField(5);
JTextField b = new JTextField(5);
JTextField delta = new JTextField(5);
JTextField intervalo = new JTextField(5);
JTextField epsilon = new JTextField(5);
JTextField vala[] = new JTextField[30];
JTextField valb[] = new JTextField[30];
JTextField solx = new JTextField(25);
JTextField solfx = new JTextField(25);
JTextArea iteracoes = new JTextArea();
JCheckBox mostraItera = new JCheckBox("Iteraçõees");
JButton calcula1 = new JButton();
JButton calcula2 = new JButton();
JButton help = new JButton();
JButton g1 = new JButton("Grafico");
JButton g2 = new JButton("Grafico");
JPanel vali;
JScrollPane vetori,caixaItera;//ScrollPane que recebe a matriz de intervalos
Expressao exp = new Expressao();
int i,op=1;
Image go,ajuda;
JTextArea textoItera = new JTextArea(10,30); //TextArea com iteraÃ§Ãµes
boolean mostra = false;
 
Raizes () { //Construtor
	
	super("Raízes de funções reais com uma variável real");
	
	for(i=0;i<30;i++){ //instancia os dois vetores de text field
		vala[i] = new JTextField(5);
		valb[i] = new JTextField(5);
	}
	
	setLayout(new BorderLayout());
	
	for(i=0;i<30;i++){ //coloca vetor val e valb e solx e solfx como nao editaveis
		(vala[i]).setEditable(false);
		(valb[i]).setEditable(false);
	}
	
	solx.setEditable(false);
	solfx.setEditable(false);
	
	try{
		go = ImageIO.read(new File("play.png"));
		ajuda = ImageIO.read(new File("help.png"));
		calcula1.setIcon(new ImageIcon(go));
		calcula2.setIcon(new ImageIcon(go));
		help.setIcon(new ImageIcon(ajuda));
	} catch(IOException e) {
		System.out.println("Não foi possível carregar os ícones, verifique se eles se encontram na mesma pasta de execução do .jar");
	}
	
	//seta valores para teste mais rapido
	fx.setText("x^3 - 10");
	a.setText("-10");
	b.setText("10");
	delta.setText("0.5");
	intervalo.setText("1");
	epsilon.setText("0.001");
	
	JPanel uniforme = new JPanel(new BorderLayout()); //Painel da parte de cima do programa
	JPanel funcs = new JPanel(); //painel que recebe os text fields e botoes responsaveis pela entrada de dados
	funcs.add(new JLabel("f(x)="));
	funcs.add(fx);
	funcs.add(new JLabel("a="));
	funcs.add(a);
	funcs.add(new JLabel("b="));
	funcs.add(b);
	funcs.add(new JLabel("Δ="));
	funcs.add(delta);
	calcula1.addActionListener(this);
	g1.addActionListener(this);
	help.addActionListener(this);
	funcs.add(calcula1);
	funcs.add(g1);
	funcs.add(help);
	uniforme.add(funcs,BorderLayout.NORTH);
	vali = criaPanelIntervalos(20,vala,valb);
	vetori = new JScrollPane(vali); //ScrollPane que recebe a matriz de intervalos
	vetori.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_NEVER);
	uniforme.add(new JLabel("Calculo de raiz para determinado intervalo 'i'"),BorderLayout.SOUTH);
	uniforme.add(vetori,BorderLayout.CENTER);
	
	JPanel seg = new JPanel(new BorderLayout()); //Painel da parte de baixo do programa
	JPanel aux = new JPanel(); //painel com os elementos da parte debaixo
	
	aux.add(new JLabel("i=")); //NORTE - Entradas
	aux.add(intervalo);
	aux.add(new JLabel("ε = ")); 
	aux.add(epsilon);
	aux.add(new JLabel("Metodo = "));
	seg.add(aux,BorderLayout.NORTH);
	JComboBox<String> caixa = criaCaixaMetodos();
	aux.add(caixa);
	mostraItera.addActionListener(new ActionListener() { //action listener da checkbox - mostrar iteraÃ§Ãµes ou nao
    public void actionPerformed(ActionEvent e) {
        JCheckBox cb = (JCheckBox)e.getSource();
        if (cb.isSelected()) {
            mostra=true;
            add(caixaItera,BorderLayout.SOUTH);
            setSize(800,425);
        	}
        else{ 
            mostra=false;
            remove(caixaItera);
            setSize(800,250);
        	}
		}
	});
	aux.add(mostraItera);
	calcula2.addActionListener(this);
	aux.add(calcula2);
	g2.addActionListener(this);
	aux.add(g2);
	seg.add(aux,BorderLayout.NORTH);
	
	JPanel sol = new JPanel(); //CENTER - SoluÃ§Ãµes
	sol.add(new JLabel("Resultado -->  "));
	sol.add(new JLabel("x = "));
	sol.add(solx);
	sol.add(new JLabel("      f(x) = "));
	sol.add(solfx);
	seg.add(sol,BorderLayout.CENTER);
	
	textoItera.setEditable(false);
	caixaItera = new JScrollPane(textoItera); //SOUTH - JTextArea que mostra iteraÃ§Ãµes
	
	add(uniforme,BorderLayout.NORTH);
	add(seg,BorderLayout.CENTER);
	//add(caixaItera,BorderLayout.SOUTH);
	pack();
	setVisible(true);
	setSize(800,250);
	//setPreferredSize(new Dimension(800,400));
	setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
	
}


double f (String func,double v) { //funÃ§Ã£o q retorna valor da funÃ§Ã£o func para um certo valor v
	
	double num=0;
	exp.variavel("x",v);
	
	try{
		num = exp.valor(func);
	}catch(Exception E) {}
	
	return num;
}
//------------------------------------------------------------------------------------------------------------------------------------
double derivada (String fexp,double x,double eps){
	
	double d = 0;
	double h = 1000*eps;
	boolean achou = false;
	double p=0,q;
	int it = 0;
	double erro = 1000000;
	int maxIt = 100;
	
	p = ( f(fexp,x+h) - f(fexp,x-h) )/(2*h);
	
	for(it=0;it<maxIt && !achou;it++) {
		
		q=p;
		h=h/2;
	
		p = ( f(fexp,x+h) - f(fexp,x-h) )/(2*h);
		
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
//-------------------------------------------------------------------------------------------------------------
JPanel criaPanelIntervalos (int n,JTextField vala[],JTextField valb[]) {
	
	int i;
	
	JPanel vali = new JPanel(new GridBagLayout());
	GridBagConstraints c = new GridBagConstraints();
	
	//fileira de numeros de 1 ate n
	c.gridx=0;
	c.gridy=0;
	c.fill = GridBagConstraints.BOTH;
	
	vali.add(new JLabel("i"),c);
	
	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vali.add(new JLabel(i+" "),c);
	}
	
	//fileira com jtextfield a
	c.gridy=1;
	c.gridx=0;
	
	vali.add(new JLabel("a[i]"),c);
	
	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vali.add(vala[i-1],c);
	}
	
	//fileira com jtextfield b
	c.gridy=2;
	c.gridx=0;
	
	vali.add(new JLabel("b[i]"),c);
	
	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vali.add(valb[i-1],c);
	}
	
	c.gridy=3;
	for(i=1;i<=n;i++){
		c.gridx=i;
		
		vali.add(new JLabel(" "),c);
	}
   
	return vali;
	
}
//-------------------------------------------------------------------------------------------------------------
JComboBox<String> criaCaixaMetodos () {
	
	JComboBox<String> caixa = new JComboBox<String>();
	caixa.addItem("Busca Uniforme");
	caixa.addItem("Método da Bisseção");
	caixa.addItem("Método das Cordas");
	caixa.addItem("Método da Cordas (Modificado)");
	caixa.addItem("Método de Newton");
	caixa.addItem("Método de Newton (Modificado)");

	ActionListener l = new ActionListener() { //listener do combobox
		public void actionPerformed(ActionEvent e) {
		 
			String str = (String)((JComboBox<?>)e.getSource()).getSelectedItem();
		 
			if (str =="Busca Uniforme") 
				op=1;
			else if (str =="Método da Bisseção")
				op=2;
			else if (str =="Método das Cordas")
				op=3;
			else if (str =="Método da Cordas (Modificado)")
				op=4;
			else if (str =="Método de Newton")
				op=5;
			else if (str =="Método de Newton (Modificado)")
				op=6;
				
      }
    };
	
	caixa.addActionListener(l);
	
	return caixa;
	
	
}
//-------------------------------------------------------------------------------------------------------------
void achaIntervalos (double da,double db,double ddel,String fx,JTextField veta[],JTextField vetb[]){
	
	int cont = 0;
	int k = 0;
	BigDecimal a,adelta,del,b; //BigDecimal - Tipo de variÃ¡vel que exclui erros
	
	a = adelta = new BigDecimal(String.valueOf(da)); //passa para big decimal, convertendo antes para string para evitar erros!
	b = new BigDecimal(String.valueOf(db)); //passa para big decimal, convertendo antes para string para evitar erros!
	del = new BigDecimal(String.valueOf(ddel)); //passa para big decimal, convertendo antes para string para evitar erros!
	
	
	while(a.doubleValue() <= b.doubleValue() && k<=10000){
		
		adelta = adelta.add(del);
		
		if(f(fx,a.doubleValue())*f(fx,adelta.doubleValue()) < 0){
			(veta[cont]).setText(String.valueOf(a.doubleValue()));
			(vetb[cont]).setText(String.valueOf(adelta.doubleValue()));
			cont++;
		}
		
		k++;
		a=adelta;
		
	}
	
	
	
}	
//-------------------------------------------------------------------------------------------------------------
double buscaUniforme (double da,double db,double deps,String fx) {
	
	int k = 1;
	BigDecimal a,adelta,eps,b; //BigDecimal - Tipo de variÃ¡vel que exclui erros
	
	a = adelta = new BigDecimal(String.valueOf(da)); //passa para big decimal, convertendo antes para string para evitar erros!
	b = new BigDecimal(String.valueOf(db)); //passa para big decimal, convertendo antes para string para evitar erros!
	eps = new BigDecimal(String.valueOf(deps)); //passa para big decimal, convertendo antes para string para evitar erros!
	
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tp\t\tf(p)\t\tq\t\tf(q)\n");
	}
		
	while(a.doubleValue() < b.doubleValue()){
		
		adelta= adelta.add(eps);
		
		if(mostra==true)
			textoItera.append(k+"\t"+a.doubleValue()+"\t\t"+f(fx,a.doubleValue())+"\t\t"+adelta.doubleValue()+"\t\t"+f(fx,adelta.doubleValue())+"\n");
		
		
		if((f(fx,a.doubleValue())*f(fx,adelta.doubleValue())) <= 0){
			if(mostra==true)
				textoItera.append("Resultado: x = "+a.doubleValue()+"    f(x) = "+f(fx,a.doubleValue()));
			
			return a.doubleValue();
		}
		
		a=adelta;
		
		k++;
	}
	
	return a.doubleValue();
}
//-------------------------------------------------------------------------------------------------------------
double metodoBissecao (double a,double b,double eps,String fx) {
	
	double p,fdex,fdep;
	int k = 1;
	boolean para = false;
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tp\t\tf(p)\t\tq\t\tf(q)\n");
	}
		
	do{
		
		p=(a+b)/2;
		
		fdex = f(fx,a);
		fdep = f(fx,p);
		
		if(mostra==true)
			textoItera.append(k+"\t"+a+"\t\t"+fdex+"\t\t"+p+"\t\t"+fdep+"\n");
		
		if(Math.abs(fdep)<eps)
			para=true;
			
		if(para==false){
		
			if(fdex*fdep < 0){ //se um sinal Ã© diferente do outro, ha raiz entre a e p
				b=p; //iguala b e p
			
			if(Math.abs(b-a)<eps){ //se o modulo entre ele for menor que eps, achou a raiz
				
				if(mostra==true)
					textoItera.append("Resultado: x = "+a+"    f(x) = "+fdex);
				
				return a;
				}
			}
		
			else //senao, nao ha raiz entre a e p
				a=p; //iguala a e p
		}
		
		k++;
		
	} while(para==false);
	
	return a;
}
//--------------------------------------------------------------------------------------------------------------
double metodoCordas (double a,double b,double eps,String fx) {
	
	int k = 1;
	double p,fdeb,fdea,fdep;
	boolean para = false;
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tp\t\tf(p)\t\tq\t\tf(q)\n");
	}
	
	do{
		
		fdea = f(fx,a);
		fdeb = f(fx,b);
		
		p=(a*fdeb - b*fdea)/(fdeb-fdea);
		fdep = f(fx,p);
		
		if(mostra==true)
			textoItera.append(k+"\t"+a+"\t"+fdea+"\t"+p+"\t"+fdep+"\n");
		
		if(Math.abs(fdep)<eps)
			para=true;
			
		if(para==false){
		
			if(fdea*fdep < 0){ //se um sinal Ã© diferente do outro, ha raiz entre a e p
				b=p; //iguala b e p
			
				if(Math.abs(b-a)<eps){ //se o modulo entre ele for menor que eps, achou a raiz
				
					if(mostra==true)
						textoItera.append("Resultado: x = "+a+"    f(x) = "+fdea);
				
					return a;
				}
			}
		
			else //senao, nao ha raiz entre a e p
				a=p; //iguala a e p
		
			k++;
		}
		
		
		
	} while(para==false);
	
	textoItera.append("Resultado: x = "+a+"    f(x) = "+fdea);
	
	return a;
	
}
//--------------------------------------------------------------------------------------------------------------
double metodoCordasMod (double a,double b,double eps,String fx) {
	
	double p,fdea,fdeb,fdep;
	int ita=0,itb=0,k=1;
	boolean para = false;
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tp\t\tf(p)\t\tq\t\tf(q)\n");
	}
	
	do{
		
		fdea = f(fx,a);
		fdeb = f(fx,b);
		
		if(ita==3){
			p=(a*fdeb/2 - b*fdea)/(fdeb/2 - fdea);
			ita=itb=0;
		}
		else if(itb==3){
			p=(a*fdeb - b*fdea/2)/(fdeb-fdea/2);
			ita=itb=0;
		}
		else
			p=(a*fdeb - b*fdea)/(fdeb-fdea);
			
		fdep = f(fx,p);
		
		if(mostra==true)
			textoItera.append(k+"\t"+a+"\t\t"+fdea+"\t\t"+p+"\t\t"+fdep+"\n");
		
		if(Math.abs(fdep)<eps)
			para=true;
			
		if(para==false){
		
			if(fdea*fdep < 0){ //se um sinal Ã© diferente do outro, ha raiz entre a e p
				b=p; //iguala b e p
			
				if(Math.abs(b-a)<eps){ //se o modulo entre ele for menor que eps, achou a raiz
				
					if(mostra==true)
						textoItera.append("Resultado: x = "+a+"    f(x) = "+fdea);
				
					return a;
				}
			}
		
			else{ //senao, nao ha raiz entre a e p
				a=p;//iguala a e p
				ita++;
				itb=0;
			}
			
			k++;
		}
		
		
	} while(para==false);
	
	if(mostra==true)
		textoItera.append("Resultado: x = "+a+"    f(x) = "+fdea);
	
	return a;
	
}
//--------------------------------------------------------------------------------------------------------------
double metodoNewton (double a,double b,double eps,String fx) {
	
	double p = a;
	double q;
	int k = 1;
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tq\t\tp\n");
	}
	
	do{
		q=p;
		p=p-(f(fx,p)/derivada(fx,p,eps));
		
		if(mostra==true)
			textoItera.append(k+"\t"+q+"\t\t"+p+"\n");
		
		k++;
	} while(Math.abs(p-q)>=eps);
	
	if(mostra==true)
		textoItera.append("Resultado: x = "+p+"    f(x) = "+f(fx,p));
	
	return p;
	
}
//--------------------------------------------------------------------------------------------------------------
double metodoNewtonMod (double a,double b,double eps,String fx) {
	
	double p = a;
	double q;
	int k=0;
	double d=0;
	
	if(mostra==true){
		textoItera.setText("");
		textoItera.append("k\tq\t\tp\n");
	}
	
	do{
		
		if(k%5==0)
			d=derivada(fx,p,eps);
		
		k++;
		
		q=p;
		p=p-(f(fx,p)/d);
		
		if(mostra==true)
			textoItera.append(k+"\t"+q+"\t\t"+p+"\n");
	
		
	} while(Math.abs(p-q)>=eps);
	
	if(mostra==true)
		textoItera.append("Resultado: x = "+p+"    f(x) = "+f(fx,p));
	
	return p;
	
}
//--------------------------------------------------------------------------------------------------------------
void zeraTextFields(JTextField a[],JTextField b[]) {
	
	int i;
	
	for(i=0;i<30;i++){
		(a[i]).setText("");
		(b[i]).setText("");
	}
	
}
//--------------------------------------------------------------------------------------------------------------

	public void actionPerformed (ActionEvent e) { //Action Listener da instancia
		
		double va=0,vb=0,veps=0,vdel=0,resx=0;
		int ind=0;
		String vfx = fx.getText();
		Container frame = null;
		boolean roda = true;
		
		if(e.getSource()==calcula1){ //funcional
		
			try{
				va = Double.parseDouble(a.getText());
				vb = Double.parseDouble(b.getText());
				vdel = Double.parseDouble(delta.getText());
			}catch(NumberFormatException EX) {
				JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
			}
			
			if(a.getText()=="" || a.getText()=="")
				roda=false;
			else
				roda=true;
			
			if(roda==true){
				zeraTextFields(vala,valb);
            	achaIntervalos(va,vb,vdel,vfx,vala,valb);
			}
		
           
		}
		else if(e.getSource()==g1){ //funcional
		
			try{
				va = Double.parseDouble(a.getText());
				vb = Double.parseDouble(b.getText());
				new JanelaGrafico (vfx,va,vb);
			}catch(NumberFormatException EX) {
				JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
			}
			
		}
		
		else if(e.getSource()==calcula2) {
			
			try{
				ind = Integer.parseInt(intervalo.getText());
				veps = Double.parseDouble(epsilon.getText());
				va = Double.parseDouble((vala[ind-1]).getText());
				vb = Double.parseDouble((valb[ind-1]).getText());
			}catch(NumberFormatException EX) {
				JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
			}
			
			
			if(op==1)
				resx = buscaUniforme(va,vb,veps,vfx);
			else if(op==2)
				resx = metodoBissecao(va,vb,veps,vfx);
			else if(op==3)
				resx = metodoCordas(va,vb,veps,vfx);
			else if(op==4)
				resx = metodoCordasMod(va,vb,veps,vfx);
			else if(op==5)
				resx = metodoNewton(va,vb,veps,vfx);
			else if(op==6)
				resx = metodoNewtonMod(va,vb,veps,vfx);
			
			solx.setText(String.valueOf(resx));
			solfx.setText(String.valueOf(f(vfx,resx)));
			
		}
		
		else if(e.getSource()==g2){ //funcional
			
			try{
				ind = Integer.parseInt(intervalo.getText());
				va = Double.parseDouble((vala[ind-1]).getText());
				vb = Double.parseDouble((valb[ind-1]).getText());
			}catch(NumberFormatException EX) {
				JOptionPane.showMessageDialog(frame, "Verifique se nenhum espaço foi deixado em branco ou se os números foram digitados corretamente", "Erro",JOptionPane.ERROR_MESSAGE);
			}
			
			new JanelaGrafico (vfx,va,vb);
		}
		
		else if(e.getSource()==help)
			new Ajuda();
		
	}
	
	public static void main (String args[]){
		new Raizes();
		
		
	}

}
