import React from "react";
import { LocationIcon } from "../Icons/LocationIcon";

interface AddreesProps {
  Address: string;
  Map: JSX.Element;
}

const Address = ({ Address, Map }: AddreesProps) => {
  return (
    <div className="card w-94 bg-base-100 shadow-xl">
      <div className="card-body">
        <div className="grid justify-center">
          <div>
            <LocationIcon />
            <span className="pl-2 text-lg font-bold">{Address}</span>
          </div>
        </div>
      </div>
      <figure>
        {Map}
      </figure>
    </div>
  )
}

export default Address;