import React, { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import WelcomeMessage from "../../components/WelcomeMessage/WelcomeMessage"
import PartyTrackerClient from "../../services/api/PartyTracker";
import Countdown from "../../components/Countdown/Countdown";


const RsvpForm = () => {

    const initialRan = useRef<boolean>(false);
    const { guestId } = useParams();

    const [guestName, setGuestName] = useState<string>("");

    const dateStr = '06/03/2023 12:00:00';
    const timezoneOffset = -5 * 60; // Central US time is GMT-5
    console.log(`${dateStr} GMT${timezoneOffset >= 0 ? '+' : ''}${timezoneOffset / 60}`);

    useEffect(() => {
        if (!initialRan.current) {
            const getGuestInfo = async (id: string) => {
                var response = await PartyTrackerClient.getGuestInfo(id);
                setGuestName(response.name)
            }

            if (guestId)
                getGuestInfo(guestId);

            return () => { initialRan.current = true }
        }

    }, [guestId]);

    return (guestName === "") ? <>Getting your guest information ....</> :
        <>
            <WelcomeMessage guestName={guestName} />
            <Countdown TargetDate={new Date("06/03/2023 12:00:00 GMT-5")}/>
            <div className="form-control">
                <label className="label">
                    <span className="label-text">Your Phone</span>
                </label>
                <label className="input-group">
                    <span>Phone</span>
                    <input type="text" placeholder="" className="input input-bordered" />
                </label>
            </div>
            <div>
                <button className="btn">Hello daisyUI</button>
            </div>

        </>
}

export default RsvpForm;