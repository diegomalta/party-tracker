import React from "react";

interface WelcomeMessageProps {
    guestName: string
}

const WelcomeMessage = ({ guestName }: WelcomeMessageProps) => {
    return (<div className="text-center font-sigmar pt-6 pb-3">
        <p className="text-2xl tracking-wider">{guestName}, You're invited!</p>
        <p className="text-7xl my-4 tracking-widest text-neutral-focus">Lina </p>
        <p className="text-2xl tracking-wider">8<sup>th</sup> Birthday Party!</p>
    </div>)
}

export default WelcomeMessage;