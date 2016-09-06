import java.awt.Dimension;
import java.awt.FontMetrics;
import java.awt.Graphics;

import javax.swing.*;

@SuppressWarnings("serial")
public class JanelaGrafico extends JFrame {
  Grafico grafico = new Grafico();

  JanelaGrafico(String func,double l1,double l2) {
  //JanelaGrafico() {
	
	super("Gráfico");
	
    add(grafico);
    pack();
    grafico.setParametros(func,l1,l2);
    setVisible(true);
    //setDefaultCloseOperation(EXIT_ON_CLOSE);
  }
/*
  public static void main(String[] args) {
    new JanelaGrafico("x",0,10);
    //new JanelaGrafico();
  }*/
}

@SuppressWarnings("serial")
class Grafico extends JPanel {
  String funcao;
  double xMin, xMax;
  double yMin, yMax;
  int xMinPx, xMaxPx;
  int yMinPx, yMaxPx;
  int passos = 1000;
  Expressao s = new Expressao();

  Grafico() {
    setPreferredSize(new Dimension(400, 400));
  }

  public void paintComponent(Graphics g) {
    calculaLimitesY(g);
    calculaLimitesX(g);
    desenhaEixoY(g);
    desenhaEixoX(g);
    desenhaFuncao(g);
  }

  private void desenhaFuncao(Graphics g) {
    double passo = (xMax - xMin) / passos;
    double x = xMin;
    int xi, yi, xf, yf;
    xi = map(x, xMin, xMax, xMinPx, xMaxPx);
    yi = map(funcao(x), yMin, yMax, yMinPx, yMaxPx);
    for (int i = 1; i <= passos; i++) {
      x += passo;
      s.variavel("x",x);
      xf = map(x, xMin, xMax, xMinPx, xMaxPx);
      yf = map(funcao(x), yMin, yMax, yMinPx, yMaxPx);
      g.drawLine(xi, yi, xf, yf);
      xi = xf;
      yi = yf;
    }
  }

  private void calculaLimitesY(Graphics g) {
    double passo = (xMax - xMin) / passos;
    double x = xMin;
    double y;
    yMin = Double.MAX_VALUE;
    yMax = -Double.MAX_VALUE;
    for (int i = 0; i <= passos; i++) {
	  s.variavel("x",x);
      y = funcao(x);
      yMin = Math.min(yMin, y);
      yMax = Math.max(yMax, y);
      x += passo;
    }
    FontMetrics fm = g.getFontMetrics();
    yMinPx = getHeight() - fm.getHeight() * 2;
    yMaxPx = fm.getHeight();
  }

  private void calculaLimitesX(Graphics g) {
    xMinPx = 0;
    double passo = (yMax - yMin) / 10;
    FontMetrics fm = g.getFontMetrics();
    double y = yMin;
    for (int i = 0; i <= 10; i++) {
      if (Math.abs(y) < passo / 100) y = 0;
      xMinPx = Math.max(xMinPx, fm.stringWidth(String.format(" %9.2g ", y)));
      y += passo;
    }
    xMaxPx = getWidth() - xMinPx;
  }

  private double funcao(double x) {
	  double num = 0;
	  try{
		num = s.valor(funcao);
	}catch(Exception e){}
	
		return num;
  }

  private void desenhaEixoY(Graphics g) {
    double y = yMin;
    double passo = (yMax - yMin) / 10;
    int yPx;
    FontMetrics fm = g.getFontMetrics();
    y = yMin;
    for (int i = 0; i <= 10; i++) {
      if (Math.abs(y) < passo / 100) y = 0;
      String str = String.format("%9.2g ", y);
      yPx = map(y, yMin, yMax, yMinPx, yMaxPx);
      g.drawString(str, xMinPx - fm.stringWidth(str), yPx);
      y += passo;
    }
    g.drawLine(xMinPx, yMinPx, xMinPx, yMaxPx);
    g.drawLine(xMaxPx, yMinPx, xMaxPx, yMaxPx);
  }

  private void desenhaEixoX(Graphics g) {
    double x = xMin;
    double passo = (xMax - xMin) / 10;
    int xPx;
    for (int i = 0; i <= 10; i++) {
      String str = String.format("%9.2g", x).trim();
      xPx = map(x, xMin, xMax, xMinPx, xMaxPx);
      g.drawString(str, xPx, yMinPx + yMaxPx);
      x += passo;
    }
    g.drawLine(xMinPx, yMinPx, xMaxPx, yMinPx);
    g.drawLine(xMinPx, yMaxPx, xMaxPx, yMaxPx);
  }

  private int map(double val, double ini, double fin, int iniPx, int finPx) {
    return (int) (iniPx + (finPx - iniPx) * (val - ini) / (fin - ini));
  }

  public void setParametros(String funcao, double xMin, double xMax) {
    this.funcao = funcao;
    this.xMin = xMin;
    this.xMax = xMax;
    repaint();
  }

}
