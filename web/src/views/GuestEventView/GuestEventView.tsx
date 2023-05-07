import React, { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import WelcomeMessage from "../../components/WelcomeMessage/WelcomeMessage"
import PartyTrackerClient from "../../services/api/PartyTracker";
import Countdown from "../../components/Countdown/Countdown";
import Address from "../../components/Address/Address";
import RsvpForm from "../../components/RsvpForm/RsvpForm";
import { ArrowDownIcon } from "../../components/Icons/ArrowDownIcon";

const AddressMap = <iframe title="Event Address" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d628.2441722981405!2d-89.50626060429421!3d43.05556542692574!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8807ae5661148cf3%3A0x2851ed5654003092!2s414%20W%20Towne%20Mall%2C%20Madison%2C%20WI%2053719!5e0!3m2!1sen!2sus!4v1683411746525!5m2!1sen!2sus" width="355" height="160" style={{ border: 0 }} allowFullScreen loading="lazy"></iframe>
const Addrs = "414 West Towne Mall, Madison, WI 53719"

const GuestEventView = () => {

    const initialRan = useRef<boolean>(false);
    const { guestId } = useParams();

    const [guestName, setGuestName] = useState<string>("");

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

    return (guestName === "") ? <div className="grid place-content-center h-screen"><progress className="progress w-56"></progress>
        <p>Getting guest information</p> </div> :
        <>
            <WelcomeMessage guestName={guestName} />
            <Countdown TargetDate={new Date("06/03/2023 12:00:00 GMT-5")} FromTo="12-2 PM" />
            <Address Address={Addrs} Map={AddressMap} />
            <div className="divider"><ArrowDownIcon /> Please RSVP <ArrowDownIcon /></div> 
            <RsvpForm guestId={guestId}/>
        </>
}

export default GuestEventView;