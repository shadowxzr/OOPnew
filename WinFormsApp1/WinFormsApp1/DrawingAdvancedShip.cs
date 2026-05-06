using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

/// <summary>
/// Класс прорисовки линкора (продвинутый объект)
/// </summary>
public class DrawingBattleship : DrawingShip
{
	/// <summary>
	/// Конструктор линкора (оба признака всегда true)
	/// </summary>
	public DrawingBattleship(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
		: base(130, 65)  // Линкор чуть больше (ширина 130, высота 65)
	{
		_entityShip = new EntityBattleship(speed, weight, bodyColor, deckCount, additionalColor);
	}

	/// <summary>
	/// Переопределенный метод прорисовки
	/// </summary>
	public override void DrawTransport(Graphics g)
	{
		if (_entityShip is null || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		int x = _startPosX.Value;
		int y = _startPosY.Value;

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// ========== КОРПУС КОРАБЛЯ (деревянный) ==========
			Point[] hullPoints = new Point[]
			{
				new Point(x + 15, y + 60),
				new Point(x + 0, y + 45),
				new Point(x + 30, y + 30),
				new Point(x + 90, y + 30),
				new Point(x + 115, y + 45),
				new Point(x + 100, y + 60)
			};

			using (SolidBrush hullBrush = new SolidBrush(Color.SaddleBrown))
			{
				g.FillPolygon(hullBrush, hullPoints);
				g.DrawPolygon(blackPen, hullPoints);
			}

			// ========== ПАЛУБА ==========
			Rectangle deck = new Rectangle(x + 25, y + 35, 75, 8);
			using (SolidBrush deckBrush = new SolidBrush(Color.Peru))
			{
				g.FillRectangle(deckBrush, deck);
				g.DrawRectangle(blackPen, deck);
			}

			// ========== МАЧТА ==========
			using (Pen mastPen = new Pen(Color.SaddleBrown, 4f))
			{
				g.DrawLine(mastPen, x + 55, y + 35, x + 55, y - 10);
			}

			// ========== БОЛЬШОЙ ПАРУС ==========
			Point[] bigSailPoints = new Point[]
			{
				new Point(x + 55, y + 5),
				new Point(x + 95, y + 20),
				new Point(x + 95, y + 35),
				new Point(x + 55, y + 35)
			};
			using (SolidBrush sailBrush = new SolidBrush(Color.WhiteSmoke))
			{
				g.FillPolygon(sailBrush, bigSailPoints);
				g.DrawPolygon(blackPen, bigSailPoints);

				// Полоски на парусе
				using (Pen linePen = new Pen(Color.LightGray, 1f))
				{
					g.DrawLine(linePen, x + 55, y + 10, x + 92, y + 23);
					g.DrawLine(linePen, x + 55, y + 15, x + 92, y + 28);
					g.DrawLine(linePen, x + 55, y + 20, x + 92, y + 33);
				}
			}

			// ========== ВЕРХУШКА МАЧТЫ И ВЫМПЕЛ ==========
			Point[] flagPoints = new Point[]
			{
				new Point(x + 55, y - 10),
				new Point(x + 75, y - 7),
				new Point(x + 55, y - 4)
			};
			using (SolidBrush flagBrush = new SolidBrush(Color.Red))
			{
				g.FillPolygon(flagBrush, flagPoints);
			}

			// ========== ОКНА КАЮТ ==========
			using (SolidBrush windowBrush = new SolidBrush(Color.Gold))
			{
				for (int i = 0; i < 4; i++)
				{
					Rectangle window = new Rectangle(x + 30 + i * 18, y + 48, 8, 8);
					g.FillEllipse(windowBrush, window);
					g.DrawEllipse(blackPen, window);
				}
			}

			// ========== УСЛОЖНЕННАЯ ЧАСТЬ: отображение количества палуб ==========
			if (_entityShip.DeckCount > 1)
			{
				using (Pen deckPen = new Pen(Color.DarkGoldenrod, 2f))
				{
					// Вторая палуба - декоративная линия
					g.DrawLine(deckPen, x + 20, y + 42, x + 100, y + 42);

					if (_entityShip.DeckCount > 2)
					{
						// Третья палуба - бортик
						g.DrawLine(deckPen, x + 15, y + 52, x + 105, y + 52);

						// Дополнительные украшения
						using (SolidBrush starBrush = new SolidBrush(Color.Gold))
						{
							PointF[] star = new PointF[5];
							float centerX = x + 60;
							float centerY = y + 52;
							float radius = 6;
							for (int i = 0; i < 5; i++)
							{
								float angle = i * 72 - 90;
								star[i] = new PointF(
									centerX + radius * (float)Math.Cos(angle * Math.PI / 180),
									centerY + radius * (float)Math.Sin(angle * Math.PI / 180)
								);
							}
							g.FillPolygon(starBrush, star);
						}
					}
				}
			}

			// ========== ЯКОРЬ У НОСА ==========
			using (Pen anchorPen = new Pen(Color.DarkGray, 2f))
			{
				g.DrawLine(anchorPen, x + 105, y + 55, x + 105, y + 65);
				g.DrawLine(anchorPen, x + 100, y + 62, x + 110, y + 62);
				g.DrawArc(anchorPen, x + 100, y + 62, 10, 6, 0, 180);
			}
		}
	}
}