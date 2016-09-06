import java.io.FileInputStream;
import java.util.Scanner;

import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;


class Ajuda extends JFrame {

/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
JTextArea txtarea = new JTextArea (20,55);
JScrollPane p;

Ajuda () {
	
	super("Ajuda");
	
	StringBuffer txt = new StringBuffer();//buffer para pegar textos dos arquivos
		
		try{
			
			FileInputStream in = new FileInputStream("ajuda.txt"); 
			Scanner sin = new Scanner(in);
			while (sin.hasNextLine()) {
				txt.append(sin.nextLine());
				txt.append("\n");
			}
		
			String str = txt.toString(); //converte stringbuffer para string
			txtarea.append(str); //adiciona string em textarea
			txtarea.setEditable(false);
			sin.close();
			in.close();
		}catch (Exception ex){
			System.out.println("Erro na abertura do arquivo!");}
			
	
		p = new JScrollPane(txtarea);
		p.setHorizontalScrollBar(null);
	
	add(p);
	setVisible(true);
	pack();
	
	
}

	public static void main (String[] args){
		
		new Ajuda();
		
	}

}










