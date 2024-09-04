﻿using OpenMPT.NET;
using Pie.Audio;

const ushort channel = 0;

// Create the Pie audio device.
AudioDevice device = new AudioDevice(48000, 1);

// Load our module, using some of the provided module options.
Module module = Module.FromMemory(File.ReadAllBytes("ag-winmare.it"), new ModuleOptions(endBehavior: EndBehavior.Stop, tempoFactor: 1.0f, pitchFactor: 1.0f));

// Create our buffers and fill them.
AudioBuffer[] buffers = new AudioBuffer[2];
for (int i = 0; i < buffers.Length; i++)
{
    // We must first advance the buffer. This function returns how many samples it advanced by (a value of 0 says the
    // song has reached the end). The number of samples MAY NOT equal the length of the buffer.
    // In the case of a stereo buffer, the number of samples return will be Buffer.Length / 2.
    int numSamples = module.AdvanceBuffer();
    
    // Create our buffers. The buffer is a floating point PCM buffer.
    buffers[i] = device.CreateBuffer(
        new BufferDescription(DataType.Pcm, new AudioFormat((byte) module.Channels, module.SampleRate, FormatType.F32)), 
        module.Buffer[..(numSamples * 2)]);
}

int currentBuffer = 0;

device.BufferFinished += (system, channel, buffer) =>
{
    // We should run our buffer filling code on a separate thread. As (currently) mixr calls this function on the audio
    // thread, it is very susceptible to stalling. As libopenmpt generates the audio in real time, tracks can often
    // stall the audio thread. By running on a separate thread, you prevent this from happening.
    // (This stalling issue MAY be fixed in later mixr versions).
    Task.Run(() =>
    {
        //Console.Write($"Filling buffer {currentBuffer}... ");
        
        // This code is similar to the code when we created the buffers.
        // Advance the buffer, and check to see if it is 0. If it is, stop the channel playing.
        int numSamples = module.AdvanceBuffer();
        if (numSamples == 0)
        {
            system.Stop(channel);
            return;
        }

        // Update the buffer with new data, and queue it again, to create circular buffers.
        system.UpdateBuffer(buffers[currentBuffer], module.Buffer[..(numSamples * 2)]);
        system.QueueBuffer(buffers[currentBuffer], channel);
        
        //Console.WriteLine("Done!");

        // Increase the current buffer, looping back round to 0 if it has run out of buffers to fill.
        currentBuffer++;
        if (currentBuffer >= buffers.Length)
            currentBuffer = 0;
    });
};

// Play the first buffer, then queue any remaining buffers.
device.PlayBuffer(buffers[0], channel, new ChannelProperties(speed: 1.0));
for (int i = 1; i < buffers.Length; i++)
    device.QueueBuffer(buffers[i], channel);

double durationSeconds = module.DurationInSeconds;
Console.WriteLine($"{(int) durationSeconds / 60:00}:{(int) durationSeconds % 60:00}");

// Sleep while the device is playing.
while (device.IsPlaying(channel))
{
    Thread.Sleep(1000);
    
    double seconds = module.PositionInSeconds;
    Console.WriteLine($"{(int) seconds / 60:00}:{(int) seconds % 60:00}");
}

// Once done, dispose of the module...
module.Dispose();

// ... the buffers...
for (int i = 0; i < buffers.Length; i++)
    device.DeleteBuffer(buffers[i]);
    
// ... and finally the device itself.
device.Dispose();