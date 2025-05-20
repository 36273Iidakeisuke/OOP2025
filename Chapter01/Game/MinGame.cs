using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class GameForm : Form {
    private const int PlayerWidth = 50;
    private const int PlayerHeight = 50;
    private const int BlockWidth = 50;
    private const int BlockHeight = 50;

    private int playerX;
    private List<Rectangle> fallingBlocks;
    private Timer gameTimer;
    private Random random;
    private int score;
    private bool gameOver;

    public GameForm() {
        this.Text = "避けるゲーム";
        this.ClientSize = new Size(800, 600);
        this.DoubleBuffered = true;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.KeyPreview = true;  // KeyPreviewを有効にする

        playerX = this.ClientSize.Width / 2 - PlayerWidth / 2;
        fallingBlocks = new List<Rectangle>();
        random = new Random();
        score = 0;
        gameOver = false;

        gameTimer = new Timer();
        gameTimer.Interval = 20; // 20msごとに更新
        gameTimer.Tick += GameTimer_Tick;
        gameTimer.Start();

        this.KeyDown += GameForm_KeyDown;  // キー入力のイベントを追加
    }

    private void GameTimer_Tick(object sender, EventArgs e) {
        if (gameOver) {
            gameTimer.Stop();
            MessageBox.Show("ゲームオーバー! スコア: " + score);
            return;
        }

        // 落ちるブロックの処理
        for (int i = fallingBlocks.Count - 1; i >= 0; i--) {
            Rectangle block = fallingBlocks[i];
            block.Y += 10;

            // ブロックが画面外に出たら削除
            if (block.Y > this.ClientSize.Height) {
                fallingBlocks.RemoveAt(i);
                score++;
            } else if (block.IntersectsWith(new Rectangle(playerX, this.ClientSize.Height - PlayerHeight, PlayerWidth, PlayerHeight))) {
                gameOver = true;
            } else {
                fallingBlocks[i] = block;
            }
        }

        // 新しいブロックをランダムに生成
        if (random.Next(100) < 5) {
            int blockX = random.Next(0, this.ClientSize.Width - BlockWidth);
            fallingBlocks.Add(new Rectangle(blockX, 0, BlockWidth, BlockHeight));
        }

        Invalidate();
    }

    private void GameForm_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Left) {
            playerX = Math.Max(0, playerX - 10); // 左に移動
        } else if (e.KeyCode == Keys.Right) {
            playerX = Math.Min(this.ClientSize.Width - PlayerWidth, playerX + 10); // 右に移動
        }
    }

    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // プレイヤーを描画
        g.FillRectangle(Brushes.Blue, playerX, this.ClientSize.Height - PlayerHeight, PlayerWidth, PlayerHeight);

        // 落ちてくるブロックを描画
        foreach (var block in fallingBlocks) {
            g.FillRectangle(Brushes.Black, block);
        }

        // スコアを表示
        g.DrawString("スコア: " + score, this.Font, Brushes.Black, 10, 10);
    }
}