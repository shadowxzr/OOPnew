using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    /// <summary>
    /// Полотно для корабля
    /// </summary>
    public class CanvasForShip
    {
        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawingShip? _drawningShip;

        /// <summary>
        /// Ширина полотна
        /// </summary>
        private int? _canvasWidth;

        /// <summary>
        /// Высота полотна
        /// </summary>
        private int? _canvasHeight;

        /// <summary>
        /// Установка границ поля
        /// </summary>
        /// <param name="width">Ширина поля</param>
        /// <param name="height">Высота поля</param>
        public void SetPictureSize(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
        }

        /// <summary>
        /// Вставить объекта "корабля"
        /// </summary>
        /// <param name="ship">Объект "корабля"</param>
        /// <returns>true - объект сохранен, false - объект нельзя поместить в имеющиеся размеры формы</returns>
        public bool InsertShip(DrawingShip ship)
        {
            // если размеры форм не заданы, то завершаем работу метода
            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            {
                return false;
            }

            // если размеры форм есть, то проверяем, что по размерам объект можно поместить в поле
            if (ship.DrawingShipWidth > _canvasWidth.Value || ship.DrawingShipHeight > _canvasHeight.Value)
            {
                return false;
            }

            // если можно, то сохраняем ссылку на объект
            _drawningShip = ship;
            return true;
        }

        /// <summary>
        /// Установка позиции объекта
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetShipPosition(int x, int y)
        {

            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningShip is null)
            {
                return;
            }

            int newX = x;
            int newY = y;

            if (newX < 0)
            {
                newX = 0;
            }
            else if (newX + _drawningShip.DrawingShipWidth > _canvasWidth.Value)
            {
                newX = _canvasWidth.Value - _drawningShip.DrawingShipWidth;
            }

            if (newY < 0)
            {
                newY = 0;
            }
            else if (newY + _drawningShip.DrawingShipHeight > _canvasHeight.Value)
            {
                newY = _canvasHeight.Value - _drawningShip.DrawingShipHeight;
            }

            _drawningShip.SetPosition(newX, newY);
        }

        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        /// <returns>true - перемещение выполнено, false - перемещение невозможно</returns>
        public bool MoveTransport(DirectionType direction)
        {
            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningShip is null ||
                !_drawningShip.PosX.HasValue || !_drawningShip.PosY.HasValue || !_drawningShip.ShipStep.HasValue)
            {
                return false;
            }

            int newX = _drawningShip.PosX.Value;
            int newY = _drawningShip.PosY.Value;
            int step = (int)_drawningShip.ShipStep.Value;

            switch (direction)
            {
                case DirectionType.Left:
                    if (newX - step >= 0)
                    {
                        _drawningShip.MoveLeft();
                        return true;
                    }
                    break;

                case DirectionType.Up:
                    if (newY - step >= 0)
                    {
                        _drawningShip.MoveUp();
                        return true;
                    }
                    break;

                case DirectionType.Right:
                    if (newX + step + _drawningShip.DrawingShipWidth <= _canvasWidth.Value)
                    {
                        _drawningShip.MoveRight();
                        return true;
                    }
                    break;

                case DirectionType.Down:
                    // прописать логику сдвига в вниз
                    if (newY + step + _drawningShip.DrawingShipHeight <= _canvasHeight.Value)
                    {
                        _drawningShip.MoveDown();
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// Прорисовка полотна
        /// </summary>
        /// <returns></returns>
        public Bitmap? DrawCanvas()
        {
            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            {
                return null;
            }

            Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                // Заливаем фон белым цветом
                graphics.Clear(Color.White);
                _drawningShip?.DrawTransport(graphics);
            }
            return bmp;
        }
    }
}
