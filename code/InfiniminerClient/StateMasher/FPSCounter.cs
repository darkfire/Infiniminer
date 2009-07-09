using System;
using System.Collections.Generic;
using System.Text;

namespace StateMasher
{
    class FPSCounter
    {
        private const int BUFFER_SIZE = 128;
        private uint[] m_millisecs = new uint[BUFFER_SIZE];
        private uint m_numFrames = 0;
        private uint m_first = 0;

        public FPSCounter()
        {
        }

        static private uint advanceIndex(uint value)
        {
            return (value + 1) % BUFFER_SIZE;
        }

        static private uint advanceIndex(uint startValue, uint increment)
        {
            return (startValue + increment) % BUFFER_SIZE;
        }

        public void frame(uint millisecs)
        {
            if ( m_numFrames == BUFFER_SIZE )
            {
                m_millisecs[m_first] = millisecs;
                m_first = advanceIndex(m_first);
            }
            else
            {
                m_millisecs[advanceIndex(m_first, m_numFrames)] = millisecs;
                ++m_numFrames;
            }
        }

        public uint fps()
        {
            if ( m_numFrames <= 1 )
            {
                return 0;
            }

            uint firstFrameTime = m_millisecs[m_first];
            uint lastFrameTime = m_millisecs[advanceIndex(m_first, m_numFrames - 1)];

            if ( lastFrameTime == firstFrameTime )
            {
                return 0;
            }

            return m_numFrames * 1000 / (lastFrameTime - firstFrameTime);
        }
    }
}
