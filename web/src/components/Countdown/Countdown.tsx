//@ts-nocheck
import React, { useState, useEffect } from "react";


interface CountdownProps {
    TargetDate: Date;
}


const Countdown = ({ TargetDate }: CountdownProps) => {
    const [days, setDays] = useState(0);
    const [hours, setHours] = useState(0);
    const [minutes, setMinutes] = useState(0);
    const [seconds, setSeconds] = useState(0);

    useEffect(() => {
        const intervalId = setInterval(() => {
            const now = new Date().getTime();
            const targetTime = (TargetDate || new Date()).getTime();
            const timeRemaining = Math.max(0, targetTime - now);

            setDays(Math.floor(timeRemaining / (1000 * 60 * 60 * 24)));
            setHours(
                Math.floor((timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
            );
            setMinutes(Math.floor((timeRemaining % (1000 * 60 * 60)) / (1000 * 60)));
            setSeconds(Math.floor((timeRemaining % (1000 * 60)) / 1000));
        }, 999);

        return () => {
            clearInterval(intervalId);
        };
    }, []);

    return (
        <div className="grid grid-flow-col gap-5 text-center auto-cols-max">
            <div className="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
                <span className="countdown font-mono text-5xl">
                    <span style={{"--value": days}}></span>
                </span>
                days
            </div>
            <div className="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
                <span className="countdown font-mono text-5xl">
                    <span style={{"--value": hours}}></span>
                </span>
                hours
            </div>
            <div className="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
                <span className="countdown font-mono text-5xl">
                    <span style={{"--value": minutes}}></span>
                </span>
                min
            </div>
            <div className="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
                <span className="countdown font-mono text-5xl">
                    <span style={{"--value": seconds}}></span>
                </span>
                sec
            </div>
        </div>
    );
}

export default Countdown;